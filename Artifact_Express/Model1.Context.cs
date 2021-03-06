﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Artifact_Express
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class MuseumEntities : DbContext
    {
        public MuseumEntities()
            : base("name=MuseumEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ARTIFACT> ARTIFACTs { get; set; }
        public virtual DbSet<ARTIFACTPRESERVATION> ARTIFACTPRESERVATIONs { get; set; }
        public virtual DbSet<ARTIFACTTYPE> ARTIFACTTYPEs { get; set; }
        public virtual DbSet<ARTIST> ARTISTs { get; set; }
        public virtual DbSet<BORROWEDLOG> BORROWEDLOGs { get; set; }
        public virtual DbSet<COLLECTION> COLLECTIONs { get; set; }
        public virtual DbSet<COUNTRY> COUNTRies { get; set; }
        public virtual DbSet<EXHIBIT> EXHIBITs { get; set; }
        public virtual DbSet<LOANEDLOG> LOANEDLOGs { get; set; }
        public virtual DbSet<LOCATION> LOCATIONs { get; set; }
        public virtual DbSet<MUSEUM> MUSEUMs { get; set; }
        public virtual DbSet<PHOTOGRAPH> PHOTOGRAPHs { get; set; }
        public virtual DbSet<STORAGEREQUIREMENT> STORAGEREQUIREMENTs { get; set; }
        public virtual DbSet<SysUser> SysUsers { get; set; }
        public virtual DbSet<TEST> TESTs { get; set; }
        public virtual DbSet<TestTool> TestTools { get; set; }
        public virtual DbSet<TESTUSED> TESTUSEDs { get; set; }
        public virtual DbSet<TIMEPERIOD> TIMEPERIODs { get; set; }
        public virtual DbSet<TREATMENTREGIMan> TREATMENTREGIMEN { get; set; }
        public virtual DbSet<TREATMENTREGIMENUSED> TREATMENTREGIMENUSEDs { get; set; }
        public virtual DbSet<TREATMENTTECHNIQUE> TREATMENTTECHNIQUEs { get; set; }
        public virtual DbSet<TREATMENTTOOL> TREATMENTTOOLS { get; set; }
    
        public virtual ObjectResult<AppraisedValueGreaterThan_Result> AppraisedValueGreaterThan(Nullable<int> appraisedNum)
        {
            var appraisedNumParameter = appraisedNum.HasValue ?
                new ObjectParameter("appraisedNum", appraisedNum) :
                new ObjectParameter("appraisedNum", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<AppraisedValueGreaterThan_Result>("AppraisedValueGreaterThan", appraisedNumParameter);
        }
    
        public virtual ObjectResult<ArtifactsBorrowed_Result> ArtifactsBorrowed(string museumName)
        {
            var museumNameParameter = museumName != null ?
                new ObjectParameter("museumName", museumName) :
                new ObjectParameter("museumName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ArtifactsBorrowed_Result>("ArtifactsBorrowed", museumNameParameter);
        }
    
        public virtual ObjectResult<ArtifactsFromTimePeriod_Result> ArtifactsFromTimePeriod(string timePeriod)
        {
            var timePeriodParameter = timePeriod != null ?
                new ObjectParameter("timePeriod", timePeriod) :
                new ObjectParameter("timePeriod", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ArtifactsFromTimePeriod_Result>("ArtifactsFromTimePeriod", timePeriodParameter);
        }
    
        public virtual ObjectResult<ArtifactsOnLoan_Result> ArtifactsOnLoan(string museumName)
        {
            var museumNameParameter = museumName != null ?
                new ObjectParameter("museumName", museumName) :
                new ObjectParameter("museumName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ArtifactsOnLoan_Result>("ArtifactsOnLoan", museumNameParameter);
        }
    
        public virtual int BorrowAnArtifact(Nullable<int> artifactID, Nullable<int> museumID, Nullable<System.DateTime> dateBorrowed, Nullable<System.DateTime> dateReturned)
        {
            var artifactIDParameter = artifactID.HasValue ?
                new ObjectParameter("ArtifactID", artifactID) :
                new ObjectParameter("ArtifactID", typeof(int));
    
            var museumIDParameter = museumID.HasValue ?
                new ObjectParameter("MuseumID", museumID) :
                new ObjectParameter("MuseumID", typeof(int));
    
            var dateBorrowedParameter = dateBorrowed.HasValue ?
                new ObjectParameter("DateBorrowed", dateBorrowed) :
                new ObjectParameter("DateBorrowed", typeof(System.DateTime));
    
            var dateReturnedParameter = dateReturned.HasValue ?
                new ObjectParameter("DateReturned", dateReturned) :
                new ObjectParameter("DateReturned", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("BorrowAnArtifact", artifactIDParameter, museumIDParameter, dateBorrowedParameter, dateReturnedParameter);
        }
    
        public virtual ObjectResult<FindArtifactLocation_Result> FindArtifactLocation(string artifactName)
        {
            var artifactNameParameter = artifactName != null ?
                new ObjectParameter("artifactName", artifactName) :
                new ObjectParameter("artifactName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FindArtifactLocation_Result>("FindArtifactLocation", artifactNameParameter);
        }
    
        public virtual ObjectResult<GetAllTestsForArtifact_Result> GetAllTestsForArtifact(string artifactName)
        {
            var artifactNameParameter = artifactName != null ?
                new ObjectParameter("artifactName", artifactName) :
                new ObjectParameter("artifactName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllTestsForArtifact_Result>("GetAllTestsForArtifact", artifactNameParameter);
        }
    
        public virtual ObjectResult<GetAllToolsUsedInTest_Result> GetAllToolsUsedInTest(string artifactName)
        {
            var artifactNameParameter = artifactName != null ?
                new ObjectParameter("artifactName", artifactName) :
                new ObjectParameter("artifactName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllToolsUsedInTest_Result>("GetAllToolsUsedInTest", artifactNameParameter);
        }
    
        public virtual ObjectResult<GetArtifactAuthentication_Result> GetArtifactAuthentication(string artifactName)
        {
            var artifactNameParameter = artifactName != null ?
                new ObjectParameter("artifactName", artifactName) :
                new ObjectParameter("artifactName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetArtifactAuthentication_Result>("GetArtifactAuthentication", artifactNameParameter);
        }
    
        public virtual ObjectResult<GetArtifactsInExhibition_Result> GetArtifactsInExhibition(string exhibitionName)
        {
            var exhibitionNameParameter = exhibitionName != null ?
                new ObjectParameter("ExhibitionName", exhibitionName) :
                new ObjectParameter("ExhibitionName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetArtifactsInExhibition_Result>("GetArtifactsInExhibition", exhibitionNameParameter);
        }
    
        public virtual ObjectResult<string> GetArtifactsInLocation(Nullable<int> room, Nullable<int> floor)
        {
            var roomParameter = room.HasValue ?
                new ObjectParameter("Room", room) :
                new ObjectParameter("Room", typeof(int));
    
            var floorParameter = floor.HasValue ?
                new ObjectParameter("Floor", floor) :
                new ObjectParameter("Floor", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("GetArtifactsInLocation", roomParameter, floorParameter);
        }
    
        public virtual ObjectResult<getSpecificCollection_Result> getSpecificCollection(string collectionName)
        {
            var collectionNameParameter = collectionName != null ?
                new ObjectParameter("CollectionName", collectionName) :
                new ObjectParameter("CollectionName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getSpecificCollection_Result>("getSpecificCollection", collectionNameParameter);
        }
    
        public virtual ObjectResult<GetStorageRequirements_Result> GetStorageRequirements(string artifactName)
        {
            var artifactNameParameter = artifactName != null ?
                new ObjectParameter("ArtifactName", artifactName) :
                new ObjectParameter("ArtifactName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetStorageRequirements_Result>("GetStorageRequirements", artifactNameParameter);
        }
    
        public virtual int LoanAnArtifact(Nullable<int> artifactID, Nullable<int> museumID, Nullable<System.DateTime> dateLoaned, Nullable<System.DateTime> dateReturned)
        {
            var artifactIDParameter = artifactID.HasValue ?
                new ObjectParameter("ArtifactID", artifactID) :
                new ObjectParameter("ArtifactID", typeof(int));
    
            var museumIDParameter = museumID.HasValue ?
                new ObjectParameter("MuseumID", museumID) :
                new ObjectParameter("MuseumID", typeof(int));
    
            var dateLoanedParameter = dateLoaned.HasValue ?
                new ObjectParameter("DateLoaned", dateLoaned) :
                new ObjectParameter("DateLoaned", typeof(System.DateTime));
    
            var dateReturnedParameter = dateReturned.HasValue ?
                new ObjectParameter("DateReturned", dateReturned) :
                new ObjectParameter("DateReturned", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("LoanAnArtifact", artifactIDParameter, museumIDParameter, dateLoanedParameter, dateReturnedParameter);
        }
    
        public virtual ObjectResult<ViewArtifactDescription_Result> ViewArtifactDescription(string artifactName)
        {
            var artifactNameParameter = artifactName != null ?
                new ObjectParameter("artifactName", artifactName) :
                new ObjectParameter("artifactName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ViewArtifactDescription_Result>("ViewArtifactDescription", artifactNameParameter);
        }
    }
}
