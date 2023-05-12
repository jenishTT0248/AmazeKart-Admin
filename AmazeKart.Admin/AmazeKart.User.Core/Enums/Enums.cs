using AmazeKart.User.Core.Utility;

namespace AmazeKart.User.Core.Enums
{
    public enum MessageType
    {
        [StringValue("Success")]
        Success = 1,
        [StringValue("Info")]
        Information = 2,
        [StringValue("Warning")]
        Warning = 3,
        [StringValue("Error")]
        Error = 4
    }

    public enum ResultMessage
    {
        [StringValue("Record Not Inserted")]
        Fail = 0,
        [StringValue("Success!")]
        Success = 1,
        [StringValue("This record already exists.")]
        RecordExists = 2,
        [StringValue("Record not found: Please edit your search and try again.")]
        RecordNotFound = 3,
        [StringValue("Your username and password were not recognized. Please review your inputs and try again.")]
        InvalidUserName = 4,
        [StringValue("Not Found")]
        NotFound = 5,
        [StringValue("OrderId and ProductId must be greater than zero.")]
        InvalidOrderDetail = 6
    }

    public enum MessageConstants
    {
        [StringValue("Record inserted successfully.")]
        RecordInsertSuccessfully,
        [StringValue("Record updated successfully.")]
        RecordupdateSuccessfully,
        [StringValue("Record deleted successfully.")]
        RecordDeleteSuccessfully
    }
}