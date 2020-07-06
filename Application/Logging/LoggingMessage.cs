using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Logging
{
    public struct LoggingMessage
    {
        public const string ProcessingRequest = "Processing {action} request";

        public const string ProcessingRequestWithParameter = "Processing {action} with search parameter: {parammeters}";

        public const string ProcessingRequestWithModel = "Processing {action} with model: \n {models}";

        public const string ProcessingRequestUpdateWithModel = "Processing {action} with Id is {objectId} and model: \n {models}";

        public const string ProcessingRequestComplete = "Processed {action} successfully. The return model: \n {model}";

        public const string ProcessingInService = "Running {action} function in {service} with params: \n {models}";

        public const string ProcessingInServiceWithoutModel = "Running {action} function in {serviceName}";

        public const string ProcessingInAzureSearchService = "Processing {indexName} index search with query: \n {query}";

        public const string ProcessingInServiceSuccessfully = "{action} function in {serviceName} completed successfully.";

        public const string ProcessingInServiceSuccessfullyWithResult = "{action} {serviceName} successfully" +
            " with result {result} ";

        public const string RequestResults = "Request results of {action} success";

        public const string CannotFoundWithId = "Cannot found {objectName} with id: {objectId}";

        public const string CannotProcess = "Cannot {action}. The error is {exceptions}";

        public const string CannotProcessWithoutAction = "Cannot process. The error is {exceptions}";

        public const string CannotProcessInService = "{action} function in {serviceName} throws an error. The error is {exceptions}";

        public const string CannotProcessWithModelNull = "Cannot {action}. The model is null";

        public const string CannotProcessWithReferenceId = "Cannot {action} with different Id: {objectId}";

        public const string CannotProcessWithSameId = "Cannot {action} with the same id: {firstObjectId}, {secondObjectId}";

        public const string CannotProcessWithUndefinedEnum = "Cannot {action} with undefined enum: {enumValue}";

        public const string ReceivedDataFromExternalService = "Received data from {externalServiceName} with response: {result}";

        public const string CannotReceivedDataFromExternalService = "Can not received data from {externalServiceName}" +
            " with {errorMessage}";
        public const string InconsistentRequest = "Inconsistent request. The id sent across the route is different from the request body id";

        public const string CannotProcessWithInvalidId = "Cannot {action} with invalid id: {objectId}";

        public const string ActionSuccessfully = "{action} successfully in {service} with object {object}.";

        public const string ActionSuccessfullyWithoutModel = "{action} successfully in {service}.";

        public const string CannotProcessWithId = "Cannot {action} in {service} with id: {id}";
    }
}
