//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCWork.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProductPage
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductPage()
        {
            this.ProductLists = new HashSet<ProductLists>();
        }
    
        public int ProductPageID { get; set; }
        public string Head { get; set; }
        public int UserId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductLists> ProductLists { get; set; }
        public virtual UserInfos UserInfos { get; set; }
    }
}
