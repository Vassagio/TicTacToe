using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xunit;

namespace Test.Utilities {
    public static class EqualityTests {
        private struct TestResult {
            public bool IsSuccess { get; private set; }
            public string ErrorMessage { get; private set; }

            public static TestResult CreateSuccess() => new TestResult {
                IsSuccess = true
            };

            public static TestResult CreateFailure(string message) => new TestResult {
                IsSuccess = false,
                ErrorMessage = message
            };
        }

        public static void TestEqualObjects<T>(T obj1, T obj2) {
            ThrowIfAnyIsNull(obj1, obj2);

            var testResults = new List<TestResult> {
                TestGetHashCodeOnEqualObjects(obj1, obj2),
                TestEquals(obj1, obj2, true),
                TestEqualsOfT(obj1, obj2, true),
                TestEqualityOperator(obj1, obj2, true),
                TestInequalityOperator(obj1, obj2, false)
            };

            AssertAllTestsHavePassed(testResults);
        }

        public static void TestUnequalObjects<T>(T obj1, T obj2) {
            ThrowIfAnyIsNull(obj1, obj2);

            var testResults = new List<TestResult> {
                TestEqualsReceivingNonNullOfOtherType(obj1),
                TestEquals(obj1, obj2, false),
                TestEqualsOfT(obj1, obj2, false),
                TestEqualityOperator(obj1, obj2, false),
                TestInequalityOperator(obj1, obj2, true)
            };

            AssertAllTestsHavePassed(testResults);
        }

        public static void TestAgainstNull<T>(T obj) {
            ThrowIfAnyIsNull(obj);

            var testResults = new List<TestResult> {
                TestEqualsReceivingNull(obj),
                TestEqualsOfTReceivingNull(obj),
                TestEqualityOperatorReceivingNull(obj),
                TestInequalityOperatorReceivingNull(obj)
            };

            AssertAllTestsHavePassed(testResults);
        }

        private static TestResult TestGetHashCodeOnEqualObjects<T>(T obj1, T obj2) {
            return SafeCall("GetHashCode",
                            () => {
                                if (obj1.GetHashCode() != obj2.GetHashCode())
                                    return TestResult.CreateFailure("GetHashCode of equal objects " + "returned different values.");
                                return TestResult.CreateSuccess();
                            });
        }

        private static TestResult TestEqualsReceivingNonNullOfOtherType<T>(T obj) {
            return SafeCall("Equals",
                            () => {
                                if (obj.Equals(new object()))
                                    return TestResult.CreateFailure("Equals returned true when comparing " + "with object of a different type.");
                                return TestResult.CreateSuccess();
                            });
        }

        private static TestResult TestEqualsReceivingNull<T>(T obj) {
            if (typeof(T).IsClass)
                return TestEquals(obj, default(T), false);
            return TestResult.CreateSuccess();
        }

        private static TestResult TestEqualsOfTReceivingNull<T>(T obj) {
            if (typeof(T).IsClass)
                return TestEqualsOfT(obj, default(T), false);
            return TestResult.CreateSuccess();
        }

        private static TestResult TestEquals<T>(T obj1, T obj2, bool expectedEqual) {
            return SafeCall("Equals",
                            () => {
                                if (obj1.Equals(obj2) != expectedEqual) {
                                    var message = $"Equals returns {!expectedEqual} " + $"on {(expectedEqual ? "" : "non-")}equal objects.";
                                    return TestResult.CreateFailure(message);
                                }
                                return TestResult.CreateSuccess();
                            });
        }

        private static TestResult TestEqualsOfT<T>(T obj1, T obj2, bool expectedEqual) {
            if (obj1 is IEquatable<T>)
                return TestEqualsOfTOnIEquatable(obj1 as IEquatable<T>, obj2, expectedEqual);
            return TestResult.CreateSuccess();
        }

        private static TestResult TestEqualsOfTOnIEquatable<T>(IEquatable<T> obj1, T obj2, bool expectedEqual) {
            return SafeCall("Strongly typed Equals",
                            () => {
                                if (obj1.Equals(obj2) != expectedEqual) {
                                    var message = "Strongly typed Equals " + $"returns {!expectedEqual} on {(expectedEqual ? "" : "non-")}equal " + "objects.";
                                    return TestResult.CreateFailure(message);
                                }
                                return TestResult.CreateSuccess();
                            });
        }

        private static TestResult TestEqualityOperatorReceivingNull<T>(T obj) {
            if (typeof(T).IsClass)
                return TestEqualityOperator(obj, default(T), false);
            return TestResult.CreateSuccess();
        }

        private static TestResult TestEqualityOperator<T>(T obj1, T obj2, bool expectedEqual) {
            var equalityOperator = GetEqualityOperator<T>();
            if (equalityOperator == null)
                return TestResult.CreateFailure("Type does not override " + "equality operator.");
            return TestEqualityOperator(obj1, obj2, expectedEqual, equalityOperator);
        }

        private static TestResult TestEqualityOperator<T>(T obj1, T obj2, bool expectedEqual, MethodInfo equalityOperator) {
            return SafeCall("Operator ==",
                            () => {
                                var equal = (bool) equalityOperator.Invoke(null, new object[] { obj1,obj2});
                                if (equal != expectedEqual) {
                                    var message = "Equality operator returned " + $"{equal} on {(expectedEqual ? "" : "non-")}equal objects.";
                                    return TestResult.CreateFailure(message);
                                }
                                return TestResult.CreateSuccess();
                            });
        }

        private static TestResult TestInequalityOperatorReceivingNull<T>(T obj) {
            if (typeof(T).IsClass)
                return TestInequalityOperator(obj, default(T), true);
            return TestResult.CreateSuccess();
        }

        private static TestResult TestInequalityOperator<T>(T obj1, T obj2, bool expectedUnequal) {
            var inequalityOperator = GetInequalityOperator<T>();
            if (inequalityOperator == null)
                return TestResult.CreateFailure("Type does not override " + "inequality operator.");
            return TestInequalityOperator(obj1, obj2, expectedUnequal, inequalityOperator);
        }

        private static TestResult TestInequalityOperator<T>(T obj1, T obj2, bool expectedUnequal, MethodInfo inequalityOperator) {
            return SafeCall("Operator !=",
                            () => {
                                var unequal = (bool) inequalityOperator.Invoke(null,new object[] {obj1,obj2});
                                if (unequal != expectedUnequal) {
                                    var message = "Inequality operator retrned " + $"{unequal} when comparing {(expectedUnequal ? "non-" : "")}equal " + "objects.";
                                    return TestResult.CreateFailure(message);
                                }
                                return TestResult.CreateSuccess();
                            });
        }

        private static void ThrowIfAnyIsNull(params object[] objects) {
            if (objects.Any(o => ReferenceEquals(o, null)))
                throw new ArgumentNullException();
        }

        private static TestResult SafeCall(string functionName, Func<TestResult> test) {
            try {
                return test();
            } catch (Exception ex) {
                var message = $"{functionName} threw {ex.GetType().Name}: {ex.Message}";

                return TestResult.CreateFailure(message);
            }
        }

        private static MethodInfo GetEqualityOperator<T>() => GetOperator<T>("op_Equality");

        private static MethodInfo GetInequalityOperator<T>() => GetOperator<T>("op_Inequality");

        private static MethodInfo GetOperator<T>(string methodName) {
            const BindingFlags BINDING_FLAGS = BindingFlags.Static | BindingFlags.Public;
            var equalityOperator = typeof(T).GetMethod(methodName, BINDING_FLAGS);
            return equalityOperator;
        }

        private static void AssertAllTestsHavePassed(IList<TestResult> testResults) {
            var allTestsPass = testResults.All(r => r.IsSuccess);
            var errors = testResults.Where(r => !r.IsSuccess).Select(r => r.ErrorMessage).ToArray();
            var compoundMessage = string.Join(Environment.NewLine, errors);

            Assert.True(allTestsPass, "Some tests have failed:\n" + compoundMessage);
        }
    }
}