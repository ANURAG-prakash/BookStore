using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Common_Layer.Models
{
    public class WishList
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string BookId { get; set; }
        public decimal Price { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string UserId { get; set; }
    }
}
