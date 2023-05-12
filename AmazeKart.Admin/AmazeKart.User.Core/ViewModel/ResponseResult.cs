using System.Net;

namespace AmazeKart.User.Core.ViewModel
{
    public partial class ResponseResult
    {
        public ResponseResult(HttpStatusCode _status, string _message, dynamic _data, string _messageType)
        {
            status = _status;
            message = _message;
            data = _data;
            messageType = _messageType;
        }
        public HttpStatusCode status { get; set; }
        public string message { get; set; }
        public dynamic data { get; set; }
        public string messageType { get; set; }
    }
}