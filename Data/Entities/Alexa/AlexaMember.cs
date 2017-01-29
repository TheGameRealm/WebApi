namespace Data.Entities.Alexa
{
    using AutoMapper.Attributes;
    using Common.DTOs.Alexa;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    [MapsTo(typeof(AlexaMemberDTO), ReverseMap = true)]
    public partial class AlexaMember
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AlexaMember()
        {
            this.Requests = new HashSet<AlexaRequest>();
        }
    
        [Key]
        public int Id { get; set; }
        [StringLength(256)]
        public string AlexaUserId { get; set; }
        public int RequestCount { get; set; }
        public System.DateTime LastRequestDate { get; set; }
        public System.DateTime CreatedDate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AlexaRequest> Requests { get; set; }
    }
}
