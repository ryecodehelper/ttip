//------------------------------------------------------------------------------
// <auto-generated>
//     이 코드는 템플릿에서 생성되었습니다.
//
//     이 파일을 수동으로 변경하면 응용 프로그램에서 예기치 않은 동작이 발생할 수 있습니다.
//     이 파일을 수동으로 변경하면 코드가 다시 생성될 때 변경 내용을 덮어씁니다.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TTIPApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class REVIEW
    {
        public int REVIEW_ID { get; set; }
        public int PID { get; set; }
        public string WRITER { get; set; }
        public Nullable<int> SCORE { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> UPDATE_DATE { get; set; }
        public string REVIEW_COMMENT { get; set; }
        public string REVIEW_IMAGE { get; set; }
        
    
        public virtual PLACE PLACE { get; set; }
    }
}