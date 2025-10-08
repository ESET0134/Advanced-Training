### Smart Home Device System
 
Task:
 
    1. Create an interface IDevice with properties DeviceName and IsOn, and methods TurnOn() and TurnOff().
    2. Create another interface ISmartDevice that inherits IDevice and adds void ConnectToWiFi(string networkName) and void ShowStatus().
 
Implement:

    Classes Light, Fan, and Thermostat that implement ISmartDevice with device-specific properties (Brightness, Speed, Temperature) respectively.
 
Create a list of ISmartDevice in Main() and perform the following:
1. Turn on all devices
2. Connect all to WiFi
3. Display their status