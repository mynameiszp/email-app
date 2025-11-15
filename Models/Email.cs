using Amazon.DynamoDBv2.DataModel;

namespace EmailApp.Models
{
    [DynamoDBTable("Emails")]
    public class Email
    {
        [DynamoDBHashKey]
        public string Id { get; set; }
        public string Topic { get; set; }
        public string Text { get; set; }
        public string FileId { get; set; }
        public DateTime CreatedAt { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public int Status { get; set; }

        public Email()
        {
            
        }
    }
}
