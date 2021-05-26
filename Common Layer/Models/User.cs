using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace CommonLayer.Models
{
    public class User
    {
        

        
        public string Email { get; set; }



       
        public string Password { get; set; }
    }
}
