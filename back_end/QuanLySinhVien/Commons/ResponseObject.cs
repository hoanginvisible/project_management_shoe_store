namespace QuanLyCuaHangBanGiay.Commons
{
    public class ResponseObject
    {
        public bool? IsSuccess { get; set; } = false;
        public object? Data { get; set; }
        public string? Message { get; set; }

        public ResponseObject(object? data, string? message)
        {
            ProcessResponseObject(data, message);
        }

        public ResponseObject(object? data)
        {
            ProcessResponseObject(data, null);
        }

        public ResponseObject(string? message)
        {
            ProcessResponseObject(null, message);
        }


        public void ProcessResponseObject(object? obj, string? mess)
        {
            if (obj != null)
            {
                IsSuccess = true;
                Data = obj;
            }

            if (mess == null)
            {
                this.Message = "";
            }

            this.Message = mess;
        }
    }
}