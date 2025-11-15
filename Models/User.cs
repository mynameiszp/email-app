using Amazon.DynamoDBv2.DataModel;

namespace EmailApp.Models
{    
    [DynamoDBTable("Users")]
    public class User
    {
        [DynamoDBHashKey]
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime CreatedAt { get; set; }

        public User()
        {
            
        }
    }
}
