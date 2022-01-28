namespace XtramileWeather.Core.Services.Response
{
    public class Result<T> where T : class
    {
        public bool Success { get; set; }
        public string Error { get; set; }
        public T Item { get; set; }
        public static Result<T> SuccessResult(T item)
        {
            return new Result<T>() { Success = true, Item = item };
        }
        public static Result<T> FailedResult(string error)
        {
            return new Result<T>() { Success = false, Error = error };
        }
    }
}
