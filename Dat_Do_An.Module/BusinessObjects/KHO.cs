using Dat_Do_An.Module.Controllers;
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

namespace Dat_Do_An.Module.BusinessObjects
{
    [DefaultClassOptions]
    [ImageName("Travel_Pub")]
    [System.ComponentModel.DisplayName("Kho")]
    [DefaultProperty("KHO")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class KHO : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public KHO(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
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

      /*  private DANHMUC _DANHMUC;
        [Association("KEY_SPN")]
        [Size(50), XafDisplayName("Danh Mục")]
        public DANHMUC DANHMUC
        {
            get { return _DANHMUC; }
            set { SetPropertyValue(nameof(DANHMUC), ref _DANHMUC, value); }
        }*/

        [Delayed(true), VisibleInListView(true)]
        [ImageEditor(ListViewImageEditorMode = ImageEditorMode.PopupPictureEdit,
            DetailViewImageEditorMode = ImageEditorMode.PictureEdit, DetailViewImageEditorFixedHeight = 340, DetailViewImageEditorFixedWidth = 227,
            ListViewImageEditorCustomHeight = 40)]
        [XafDisplayName("Ảnh")]
        public byte[] AnhSPN
        {
            get { return GetDelayedPropertyValue<byte[]>(nameof(AnhSPN)); }
            set { SetDelayedPropertyValue(nameof(AnhSPN), value); }
        }

        private string _MaSP;
        [Size(50), XafDisplayName("Mã Nguyên Liệu:")]
        [RuleRequiredField("SANPHAM", DefaultContexts.Save, "MSPN khong duoc de trong")]
        [RuleUniqueValue, Indexed(Unique = true)]
        public string MaSP
        {
            get { return _MaSP; }
            set { SetPropertyValue<string>(nameof(MaSP), ref _MaSP, value); }
        }
        private string _TenSP;
        [Size(50), XafDisplayName("Tên Nguyên Liệu:")]
        public string TenSPN
        {
            get { return _TenSP; }
            set { SetPropertyValue<string>(nameof(TenSPN), ref _TenSP, value); }
        }
        private string _DVT;
        [Size(50), XafDisplayName("Đơn Vị Tính Nguyên Liệu:")]
        public string DVT
        {
            get { return _DVT; }
            set { SetPropertyValue<string>(nameof(DVT), ref _DVT, value); }
        }

        private decimal _GiaSP;
        [XafDisplayName("Giá")]
        [ModelDefault("DisplayFormat", "{0:n0} VND")]
        [ModelDefault("EditMask", "n0")]
        public decimal GiaSP
        {
            get { return _GiaSP; }
            set { SetPropertyValue<decimal>(nameof(GiaSP), ref _GiaSP, value); }
        }

        [DevExpress.Xpo.Aggregated, Association("KEY_SPNN")]
        public XPCollection<PHIEUXUAT> _PHIEUXUAT
        {
            get { return GetCollection<PHIEUXUAT>(nameof(_PHIEUXUAT)); }
        }

        [DevExpress.Xpo.Aggregated, Association("KEY_SPNX")]
        public XPCollection<PHIEUNHAP> _PHIEUNHAP
        {
            get { return GetCollection<PHIEUNHAP>(nameof(_PHIEUNHAP)); }
        }


    }
}