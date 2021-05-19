using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace cvManagement.Models
{
    public class UserProfile
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public int PositionId { get; set; }
        public int SourceId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [cvManagement.Models.CustomValidationAttribute.ValidDate(ErrorMessage = "Ngày không được lớn hơn ngày hiện tại.")]
        public DateTime ApplyDate { get; set; }

        public int CvResult { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime InterviewDate { get; set; }

        public int InterviewResult { get; set; }

        public int Status { get; set; }

        public string CvLink { get; set; }

        public string Note { get; set; }
        public List<UserProfile> ListProfile { get; set; }
        public List<Position> listPosition { get; set; }
        public List<Source> listSource { get; set; }

        public UserProfile()
        {
        }
    }
}