using System;

namespace Arrow.DeveloperTest.Common
{
    /// <summary>
    /// the result class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Result<T>
    {
        /// <summary>
        /// check if the result is success
        /// </summary>
        public bool IsSuccess { get; }

        /// <summary>
        /// to get the value
        /// </summary>
        public T Value { get; }

        /// <summary>
        /// to get the error
        /// </summary>
        public string Error { get; }

        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="isSuccess">isSuccess.</param>
        /// <param name="value">value.</param>
        /// <param name="error">error.</param>
        private Result(bool isSuccess, T value, string error)
        {
            IsSuccess = isSuccess;
            Value = value;
            Error = error;
        }

        /// <summary>
        /// to get the success result
        /// </summary>
        /// <param name="value">value.</param>
        /// <returns></returns>
        public static Result<T> Success(T value) => new Result<T>(true, value, null);


        /// <summary>
        /// to get the fail result
        /// </summary>
        /// <param name="error">the error.</param>
        /// <returns></returns>
        public static Result<T> Fail(string error) => new Result<T>(false, default, error);
    }
}
