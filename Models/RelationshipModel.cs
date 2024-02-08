using System;
namespace greenAssignment.Models
{
	public class RelationshipModel
	{
		public int RelationshipID { get; set; }
		public int Person1ID { get; set; }
		public int Person2ID { get; set; }
		public string RelationshipType { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int UpdatedBy { get; set; }
    }
}

