using System.ServiceModel;
using WPF.DashboardImpl.DTOs.Tests;
using WPF.DashboardLibrary.Interfaces;

namespace WPF.DashboardImpl.WCF.Interfaces
{
    /// <summary>
    /// This Interface unites the Starter Portion of the Dashboard WCF Connection Callbacks in <see cref="IDashboardStarterServiceCallback"/>
    /// And the Implementation Portion of the Dashboard WCF Connection Callbacks in <see cref="IDashboardImplServiceCallback"/>
    /// </summary>
    [ServiceContract(SessionMode = SessionMode.Required)]
    public interface IDashboardServiceCallback : IDashboardStarterServiceCallback
    {
        #region Tests
        /// <summary>
        /// Notify the User of the Result of a Test. Either run by them or by someone else.
        /// </summary>
        [OperationContract(IsOneWay = true)]
        void TestResult(TestResultDTO result);
        #endregion
    }
}