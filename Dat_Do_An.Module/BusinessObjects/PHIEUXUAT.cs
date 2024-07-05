using Dat_Do_An.Module.BusinessObjects;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Dat_Do_An.Module.Controllers
{
    [DefaultClassOptions]
    [System.ComponentModel.DisplayName("Phiếu Xuất")]
    [ImageName("BO_Contract")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class PHIEUXUAT : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public PHIEUXUAT(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            if (Session.IsNewObject(this))
            {

            }
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }
        //private string _PersistentProperty;
        //[XafDisplayName("My display name"), ToolTip("My hint message")]
        //[ModelDefault("EditMask", "(000)-00"), Index(0), VisibleInListView(false)]
        //[Persistent("DatabaseColumnName"), RuleRequiredField(DefaultContexts.Save)]
        //public string PersistentProperty {
        //    get { return _PersistentProperty; }
        //    set { SetPropertyValue(nameof(PersistentProperty), ref _PersistentProperty, value); }
        //}

        //[Action(Caption = "My UI Action", ConfirmationMessage = "Are you sure?", ImageName = "Attention", AutoCommit = true)]
        //public void ActionMethod() {
        //    // Trigger a custom business logic for the current record in the UI (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112619.aspx).
        //    this.PersistentProperty = "Paid";
        //}
        private KHACHHANG _KHACHHANG;
        [Association("KEY_KHX")]
        [Size(50), XafDisplayName("Khách Hàng")]
        public KHACHHANG KHACHHANG
        {
            get { return _KHACHHANG; }
            set { SetPropertyValue<KHACHHANG>(nameof(KHACHHANG), ref _KHACHHANG, value); }
        }

        private string _SoCT;
        [Size(50), XafDisplayName("Số chứng từ")]
        public string SoCT
        {
            get { return _SoCT; }
            set { SetPropertyValue<string>(nameof(SoCT), ref _SoCT, value); }
        }


        private DateTime _NgayCT;
        [XafDisplayName("Ngày chứng từ")]
        [ModelDefault("EditMask", "dd/MM/yyyy HH:mm")]
        [ModelDefault("DisplayFormat", "{0: dd/MM/yyyy HH:mm}")]
        public DateTime NgayCT
        {
            get { return _NgayCT; }
            set { SetPropertyValue<DateTime>(nameof(NgayCT), ref _NgayCT, value); }
        }


        private string _SoHD;
        [Size(50), XafDisplayName("Số hóa đơn")]

        public string SoHD
        {
            get { return _SoHD; }
            set { SetPropertyValue<string>(nameof(SoHD), ref _SoHD, value); }
        }


        private DateTime _NgayHD;
        [XafDisplayName("Ngày hóa đơn")]
        [ModelDefault("EditMask", "dd/MM/yyyy HH:mm")]
        [ModelDefault("DisplayFormat", "{0: dd/MM/yyyy HH:mm}")]
        public DateTime NgayHD
        {
            get { return _NgayHD; }
            set { SetPropertyValue<DateTime>(nameof(NgayHD), ref _NgayHD, value); }
        }


        private NHANVIEN _NHANVIEN;
        [Association("KEY_NVX")]
        [Size(50), XafDisplayName("Nhân Viên")]
        public NHANVIEN NHANVIEN
        {
            get { return _NHANVIEN; }
            set { SetPropertyValue<NHANVIEN>(nameof(NHANVIEN), ref _NHANVIEN, value); }
        }

    
        private string _Ghichu;
        [Size(50), XafDisplayName("Ghi chú")]
        public string Ghichu
        {
            get { return _Ghichu; }
            set { SetPropertyValue<string>(nameof(Ghichu), ref _Ghichu, value); }
        }


        [DevExpress.Xpo.Aggregated, Association("KEY_DPX")]
        public XPCollection<DONGXUAT> DONGXUAT
        {
            get { return GetCollection<DONGXUAT>(nameof(DONGXUAT)); }
        }
       
        private decimal _Tongtien;

        [XafDisplayName("Tổng tiền")]
        [ModelDefault("DisplayFormat", "{0:n0} VND")]
        [ModelDefault("EditMask", "n0")]
        public decimal Tongtien
        {
            get { return _Tongtien; }
            set { SetPropertyValue(nameof(Tongtien), ref _Tongtien, value); }
        }

        private KHO _KHO;
        [Association("KEY_SPNN")]
        [Size(50), XafDisplayName("Tên Nguyên Liệu Nhập")]
        public KHO KHO
        {
            get { return _KHO; }
            set { SetPropertyValue<KHO>(nameof(KHO), ref _KHO, value); }
        }

    }
}