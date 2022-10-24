﻿using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using WiSamEntities = Wisdot.Bos.WiSam.Core.Domain.Models;
using System.Text;
using System.Threading.Tasks;
using WisDot.Bos.Sct.Core.Data;
using WisDot.Bos.Sct.Core.Domain.Models;
using GMap.NET.WindowsForms.Markers;

namespace WisDot.Bos.Sct.Core.Domain.Services.Interfaces
{
    public interface IDatabaseService
    {
        bool CloseDatabaseConnection(string dataSource);
        bool OpenDatabaseConnection(string dataSource);
        string GetStructureOwnerAgencyCode(string structureId);
        int GetUnapprovedWindowCurrentFyPlus();
        void ExecuteInsertUpdateDelete(string qry, SqlParameter[] prms, SqlConnection conn);
        void ExecuteInsertUpdateDelete(string qry, SqlConnection conn);
        DataTable ExecuteSelect(string qry, SqlConnection conn);
        DataTable ExecuteSelect(string qry, SqlParameter[] prms, SqlConnection conn);
        DataTable ExecuteSelect(string qry, OracleConnection conn);
        DataTable ExecuteSelect(string qry, OracleParameter[] prms, OracleConnection conn);
        UserAccount GetUserAccount(int userDbId);
        UserAccount GetUserAccount(string userName, string userPassword);
        ImpersonationUser GetImpersonationUser();
        bool AuthenticateUser(string userName, string userPassword);
        void LogUserActivity(int userDbId, string activity);
        DataTable GetEligibleWorkConceptsDataTable(int fiscalYear);
        List<WorkConcept> GetAllWorkConcepts();
        List<WorkConcept> GetPrimaryWorkConcepts();
        List<WorkConcept> GetSecondaryWorkConcepts();
        WorkConcept GetEligibleWorkConcept(int workConceptDbId);
        void PopulateProject(Project project, DataRow dr);
        List<Project> GetDeletedWorkConceptsForStructure(string structureId);
        List<Project> GetDeletedProjectsForStructure(string structureId);
        string GetRegionNotes(WorkConcept currentWorkConcept);
        WorkConcept GetStructureCertification(WorkConcept currentWorkConcept);
        WorkConcept GetStructurePrecertification(WorkConcept currentWorkConcept);
        Project GetProjectRecertification(int projectDbId);
        void UpdateTimeWindows();
        List<Project> MigrateExcelProjects(List<Project> projects, List<WorkConcept> eligibles);
        int AddProjectWorkConceptHistory(int projectHistoryDbId, WorkConcept wc);
        int AddProposedWorkConcept(WorkConcept wc);
        int AddProject(Project project, DateTime timeStamp);
        int AddProjectHistory(Project project, DateTime timeStamp);
        List<Project> GetProjectsInSct(int startFiscalYear, int endFiscalYear, string region = "any");
        DateTime CalculateAcceptablePseDateStart(int fiscalYear);
        DateTime CalculateAcceptablePseDateEnd(int fiscalYear);
        List<int> GetUserIdsForAProject(int projectDbId);
        List<Project> GetStructureProjects(int startFiscalYear, int endFiscalYear, string region = "any");
        string GetWorkflowStatus(Project project);
        string GetLastPrecertificationOrCertification(int projectDbId, string action = "precertification");
        List<StructuresProgramType.ProjectUserAction> GetProjectUserActionHistory(int projectDbId);
        string GetProjectHistory(int projectDbId);
        List<ElementWorkConcept> GetElementWorkConceptPairings(string structureId, int projectWorkConceptHistoryDbId, DateTime certificationDateTime);
        List<Project> GetStructureProjects(int fiscalYear, string region = "any");
        List<Project> GetFiipsProjects(int startFiscalYear, int endFiscalYear, string region = "any");
        List<Project> GetProjectsInFiips(int startFiscalYear, int endFiscalYear, List<WorkConcept> workConcepts, string region = "any");
        List<Project> GetFiipsProjects(string region, int startFiscalYear, int endFiscalYear);
        List<Project> GetFiipsProjects(int fiscalYear, string region = "any");
        List<WorkConcept> GetFiipsWorkConcepts(int startFiscalYear, int endFiscalYear, string region = "any");
        List<WorkConcept> GetProposedWorkConcepts(int startFiscalYear, int endFiscalYear, string region = "any");
        void DeactivateProposedWorkConcept(int workConceptDbId, string structureId);
        List<WorkConcept> GetEligibleWorkConcepts(int startFiscalYear, int endFiscalYear, string region = "any");
        List<WorkConcept> GetEligibleWorkConcepts(int fiscalYear, string region);
        List<WorkConcept> GetQuasicertifiedWorkConcepts(int startFiscalYear, int endFiscalYear, string region = "any");
        List<WorkConcept> GetQuasicertifiedWorkConcepts(int fiscalYear);
        List<WorkConcept> GetQuasicertifiedWorkConcepts(int fiscalYear, string region);
        string GetProposedWorkReasonCategory(string structureId);
        string GetPrecertificationLiaison(int projectDbId);
        List<WorkConcept> GetEligibleWorkConcepts(int fiscalYear);
        List<WorkConcept> GetFiipsWorkConcepts(int fiscalYear, string region);
        List<WorkConcept> GetFiipsWorkConcepts(int fiscalYear);
        List<string> GetStructuresByRegions(List<string> regions, bool stateOwned, bool localOwned, bool includeCStructures = false);
        List<string> GetStructuresByRegionForGisDataPull(string region);
        List<string> GetStateStructuresByRegionForGisDataPull(string region);
        List<string> GetStructuresByRegion(string region, bool stateOwned, bool localOwned, bool includeCStructures = false);
        Structure GetSptStructure(string structureId);
        WiSamEntities.Structure GetStructure(string strId, bool includeClosedBridges = false, bool interpolateNbi = false, bool includeCoreInspections = false,
                                        bool countTpo = false, int startYear = 0, int endYear = 0);
        List<UserAccount> GetTopUsers();
        GeoLocation GetStructureLatLong(string structureId);
        GeoLocation GetStructureGeoLocation(string structureId);
        string ConvertDegreesMinutesSecondsToDecimalDegrees(string degreesMinutesSeconds);
        bool IsProjectIdInFiips(string projectId);
        bool IsStructureInHsi(string structureId, UserAccount userAccount = null);
        WiSamEntities.StructureWorkAction GetStructureWorkAction(string workActionCode);
        void GetMainSpanInfo(WiSamEntities.Structure str);
        WiSamEntities.Inspection GetLastInspection(string strId);
        List<WiSamEntities.Element> GetLastInspectionElements(string strId);
        WiSamEntities.NbiRating GetLastNbiRating(string strId);
        void GetSpanInfo(WiSamEntities.Structure str);
        GMarkerGoogleType GetMapMarkerType(string workConceptCode);
        List<string> FindStructuresNearMe(string id, StructuresProgramType.ObjectType objectType, float midLatitude, float midLongitude, float radius, string structureTypes = "'B','P'", 
            bool stateOwned = true, bool localOwned = false, string region = "any");
        List<Structure> FindNearMeStructures
            (float latPoint, float longPoint, float radius,
                string structureId, bool stateOwned, bool localOwned,
                string structureTypes, string region = "any");
        List<Structure> FindNearMeStructures(string structureId, float minLat, float maxLat,
                                                    float minLng, float maxLng);
        void UpdateOldEvs();
        void UpdateLatLong();
        List<WorkConcept> GetProjectWorkConceptHistory(string structureId, int workConceptDbId, Project project);
        string GetPrecertificationLiaisonsEmails();
        string GetCertificationLiaisonsEmails();
        string GetCertificationSupervisorsEmails();
        UserAccount GetPrecertificationSubmitter(int projectDbId);
        void UpdatePrecertifier(Project project, List<WorkConcept> workConcepts);
        void CertifyProject(Project project, StructuresProgramType.ProjectUserAction userAction);
        void UpdateWorkConceptCertification(List<ElementWorkConcept> elementWorkConceptCombinations, WorkConcept workConcept);
        void UpdateWorkConceptPrecertificationInternalComments(string internalComments, int projectWorkConceptHistoryDbId);
        void UpdateWorkConceptPrecertification(Project project, WorkConcept workConcept);
        void SaveCertifier(int liaisonUserDbId, string liaisonType, Project project, List<WorkConcept> workConcepts, UserAccount userAccount);
        void UpdateCertifier(Project project, List<WorkConcept> workConcepts);
        void UpdateProjectCertification(Project project, StructuresProgramType.PrecertificatioReviewDecision decision);
        List<UserAccount> GetPrecertLiaisons();
        List<UserAccount> GetCertLiaisons();
        List<UserAccount> GetCertSups();
        List<UserAccount> GetUsersOfARoleType(string roleType);
        string GetRegionComboCode(string region);
        List<string> GetProposedWorkConceptJustifications();
        void UpdateProjectBoxId(int projectDbId, string boxId);
        int InsertProposedWorkConcept(WorkConcept workConcept);
        bool IsWorkConceptPrimary(string workActionCode);
        string FormatEmailAddresses(string addresses);
        void UpdateProjectWhileInPrecertificationOrCertification(Project project);
        int InsertProject(Project project);
        int InsertProjectWorkConcept(int projectHistoryDbId, WorkConcept wc);
        string GetEmailAddressesRegionalTransactors(List<int> userIds);
        string GetEmailAddress(int userDbId);
        string GetEmailAddresses(List<int> userIds);
        void UpdateProjectFosProjectId(int projectHistoryDbId, string fosProjectId);
        void DeleteProject(int projectDbId);
        string GetWorkConceptDescription(string workActionCode);
        List<UserActivity> GetUserActivities();
        void UpdateEligibleWorkConcepts();
        void UpdateGeneratedDate();
        void UpdateWorkActionCode(WorkConcept wc);
        void UpdateRegionNumber();
        void UpdateStructureProgramReviewCurrent();
        string[] ParseWorkConceptFullDescription(string workConcept);
        int GetFiscalYear();
        string GetProposedWorkNotes(string structureId);
        List<Project> GetProjectsInFiips();
        List<WorkConcept> GetFiipsWorkConcepts();
        List<Project> GetProjectsInSct();
        string GetCertificationRootFolder();
        string GetCertificationDirectory();
        string GetBosCdTemplate();
        string GetTempDirectory();
        string GetBosCdSignature();
        string GetApplicationMode();
        string GetWisamsExecutablePath();
        string GetFiipsQueryToolExecutablePath();
        bool EnableHsis();
        bool EnableBox();
        List<UserAccount> GetPrecertificationLiaisons();
        string GetPrecertificationLiaisonsEmailAddresses();
        List<UserAccount> GetCertificationLiaisons();
        string GetCertificationLiaisonsEmailAddresses();
        string GetCertificationSupervisorsEmailAddresses();
        string GetMyDirectory();
        List<WorkConcept> GetEligibleWorkConcepts();
        Wisdot.Bos.Dw.Database GetWarehouseDatabase();
        string GetCertificationLiaison(int projectDbId);
        string GetWorkflowTransaction(StructuresProgramType.ProjectUserAction projectUserAction);

    }
}
