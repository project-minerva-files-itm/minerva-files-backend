namespace SharedLibrary.Responses
{
    public class ActionResponse<T>
    {
        public bool WasSuccess { get; private set; }
        public string? Message { get; private set; }
        public T? Result { get; private set; }

        private ActionResponse() { }

        public class Builder
        {
            private readonly ActionResponse<T> _response = new();

            public Builder SetSuccess(bool wasSuccess)
            {
                _response.WasSuccess = wasSuccess;
                return this;
            }

            public Builder SetMessage(string message)
            {
                _response.Message = message;
                return this;
            }

            public Builder SetResult(T result)
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
