using Autofac;
using Csla;
using DtoPortal;
using Example.Dal;
using ObjectPortal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
namespace Example.Lib
{
    [Serializable]
    public class BusinessItem : Csla.BusinessBase<BusinessItem>, IBusinessItem
    {


        public static readonly PropertyInfo<Guid> CriteriaProperty = RegisterProperty<Guid>(c => c.Criteria);
        public Guid Criteria
        {
            get { return GetProperty(CriteriaProperty); }
            set { SetProperty(CriteriaProperty, value); }
        }

        public static readonly PropertyInfo<Guid> UniqueIDProperty = RegisterProperty<Guid>(c => c.FetchID);
        public Guid FetchID
        {
            get { return GetProperty(UniqueIDProperty); }
            set { SetProperty(UniqueIDProperty, value); }
        }


        public static readonly PropertyInfo<Guid> UpdatedIDProperty = RegisterProperty<Guid>(c => c.UpdatedID);
        public Guid UpdatedID
        {
            get { return GetProperty(UpdatedIDProperty); }
            set { SetProperty(UpdatedIDProperty, value); }
        }

        public static readonly PropertyInfo<Guid> ScopeIDProperty = RegisterProperty<Guid>(c => c.ScopeID);
        public Guid ScopeID
        {
            get { return GetProperty(ScopeIDProperty); }
            set { SetProperty(ScopeIDProperty, value); }
        }

        public void Fetch(BusinessItemDto dto)
        {
            MarkAsChild();
            this.FetchID = dto.FetchUniqueID;
            this.Criteria = dto.Criteria;
        }

        public BusinessItemDto CreateDto()
        {
            return new BusinessItemDto() { FetchUniqueID = FetchID };
        }

        /// <summary>
        /// Key point of this whole approach
        /// After an update we send the updated DTO back to it's originator
        /// So that we can get updated information like primary keys, etc
        /// </summary>
        /// <param name="dto"></param>
        public void UpdatedDto(BusinessItemDto dto)
        {
            this.UpdatedID = dto.UpdateUniqueID;
        }

        //private void Child_Create()
        //{
        //    CheckNullDependencies();

        //    using (BypassPropertyChecks)
        //    {
        //        UniqueID = Guid.NewGuid();
        //        ScopeID = getScopeID.ID;
        //    }
        //}

        //private void Child_Create(int criteria)
        //{
        //    CheckNullDependencies();

        //    using (BypassPropertyChecks)
        //    {
        //        UniqueID = Guid.NewGuid();
        //        ScopeID = getScopeID.ID;
        //        this.Criteria = criteria;
        //    }
        //}

        //private void Child_Fetch()
        //{
        //    CheckNullDependencies();

        //    using (BypassPropertyChecks)
        //    {
        //        UniqueID = Guid.NewGuid();
        //        ScopeID = getScopeID.ID;
        //        DAL.Fetch();
        //    }
        //}

        //private void Child_Fetch(int criteria)
        //{
        //    CheckNullDependencies();

        //    using (BypassPropertyChecks)
        //    {
        //        UniqueID = Guid.NewGuid();
        //        ScopeID = getScopeID.ID;
        //        DAL.Fetch();
        //        this.Criteria = criteria;
        //    }
        //}

        //private void Child_Update()
        //{
        //    CheckNullDependencies();

        //    DAL.Update();
        //}

        //private void Child_Insert()
        //{
        //    CheckNullDependencies();

        //    DAL.Insert();
        //}


        //private void CheckNullDependencies()
        //{
        //    if (this.getScopeID == null)
        //    {
        //        throw new ArgumentNullException(nameof(getScopeID));
        //    }

        //    if (this.DAL == null)
        //    {
        //        throw new ArgumentNullException(nameof(DAL));
        //    }

        //}

        ////protected override void Child_OnDataPortalInvoke(DataPortalEventArgs e)
        ////{
        ////    base.Child_OnDataPortalInvoke(e);


        ////    getScopeID = ((IDIScope)((object[])e.Object)[0]).Resolve<IUniqueScopeID>();

        ////}



    }
}
