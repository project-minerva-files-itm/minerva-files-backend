namespace SharedLibrary.Responses
{
    public class ActionResponse<T>
    {
        public bool WasSuccess { get; private set; } = true;
        public string? Message { get; private set; }
        public T? Result { get; private set; }

        private ActionResponse() { }

        public class ActionResponseBuilder
        {
            private readonly ActionResponse<T> _response = new();

            public ActionResponseBuilder SetSuccess(bool wasSuccess)
            {
                _response.WasSuccess = wasSuccess;
                return this;
            }

            public ActionResponseBuilder SetMessage(string message)
            {
                _response.Message = message;
                return this;
            }

            public ActionResponseBuilder SetResult(T result)
            {
                _response.Result = result;
                return this;
            }

            public ActionResponse<T> Build()
            {
                return _response;
            }
        }
    }
}
