# Fitbit-Api-GarethWallis

Fitbit-Api-GarethWallis is a .NET class library designed to interact with the Fitbit Web API. It simplifies the process of sending requests and processing responses from Fitbit's services.

## Features

- **Token-Based Requests**: The library takes an existing access token to authenticate requests.
- **API Coverage**: Facilitates data retrieval and interactions with Fitbit's Web API, handling various endpoints and data types.
- **Parameter Flexibility**: Allows you to specify parameters for different data requests without managing the underlying HTTP requests.

## Getting Started

To use Fitbit-Api-GarethWallis, you must have an access token obtained from Fitbit's OAuth authentication process. This library does not handle the initial OAuth authorization and must be used in conjunction with a valid access token.

### Installation

Install Fitbit-Api-GarethWallis via NuGet:

```bash
Install-Package Fitbit-Api-GarethWallis


```csharp
using FitbitApiClient;

var fitbitclient = new FitbitClient("access_token");

var hrvDataSingleDay = await fitbitclient.GetHrvIntradayDataForSingleDayAsync(DateTime.UtcNow);

var hrvDataMultipleDays = await fitbitclient.GetHrvIntradayDataForMultipleDaysAsync(DateTime.UtcNow.AddDays(-2), DateTime.UtcNow);