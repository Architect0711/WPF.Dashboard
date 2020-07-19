using System.Collections.Generic;
using System.ServiceModel;
using WPF.DashboardImpl.DTOs.Tests;
using WPF.DashboardLibrary.Interfaces;

namespace WPF.DashboardImpl.WCF.Interfaces
{
    /// <summary>
    /// This Interface unites the Starter Portion of the Dashboard WCF Connection in <see cref="IDashboardStarterService"/>
    /// An example Implementation can be found in the class <see cref="DashboardService"/> 
    /// https://stackoverflow.com/questions/2504199/can-a-wcf-contract-use-multiple-callback-interfaces
    /// </summary>
    [ServiceContract(SessionMode = SessionMode.Required, CallbackContract = typeof(IDashboardServiceCallback))]
    public interface IDashboardService: IDashboardStarterService
    {
        #region Tests
        /// <summary>
        /// Provide the Dashboard with a List of Tests the User can run on the System
        /// </summary>
        /// <param name="UserId">The logged in User, to check if they have Permission to see the Test</param>
        /// <returns></returns>
        [OperationContract(IsOneWay = false)]
        List<TestDTO> GetAvailableTests(string UserId);

        /// <summary>
        /// Let the User run Tests on the System
        /// </summary>
        /// <param name="test">The Test to run</param>
        /// <param name="UserId">The logged in User, to check if they have Permission to run the Test</param>
        [OperationContract(IsOneWay = true)]
        void RequestTest(TestRequestDTO test, string UserId);
        #endregion

    }
}
