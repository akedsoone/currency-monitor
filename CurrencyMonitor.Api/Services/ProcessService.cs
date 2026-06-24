using CurrencyMonitor.Api.Interfaces;

namespace CurrencyMonitor.Api.Services
{
    public class ProcessService(IApiService apiService, IAvailabilityRecordService availability) : IProcessService
    {
        private readonly IApiService _apiService = apiService ?? throw new ArgumentNullException(nameof(apiService));
        private readonly IAvailabilityRecordService _availability = availability ?? throw new ArgumentNullException(nameof(availability));

        public async Task ProcessAsync()
        {
            var apiResponse = await _apiService.GetAmountsAsync();

            if (apiResponse?.DepartmentAmounts == null)
            {
                Console.WriteLine("Нет данных от API - DepartmentAmounts = null");
                return;
            }

            DateTime dateTime = DateTime.UtcNow;

            foreach (var departmentResponse in apiResponse.DepartmentAmounts)
            {
                await _availability.SaveDepartmentResponseAsync(
                    departmentResponse,
                    dateTime);
            }
        }
    }
}