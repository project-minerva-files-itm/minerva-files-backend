using Newtonsoft.Json;
using SharedLibrary.DTOs;

namespace SharedLibrary.Responses
{
    public class ActionResponse<T>
    {
        public bool WasSuccess { get; private set; } = true;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string? Message { get; private set; }

        public T? Result { get; private set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public PaginationDTO? Pagination { get; private set; }

        public ActionResponse()
        { }

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

            public ActionResponseBuilder SetPagination(PaginationDTO Pagination)
            {
                Pagination.Page++;
                _response.Pagination = Pagination;
                return this;
            }

            public ActionResponse<T> Build()
            {
                return _response;
            }
        }
    }
}