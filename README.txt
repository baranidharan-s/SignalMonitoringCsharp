# SignalMonitoringCsharp

Folder Explanation:
1. ConsoleSignalValidatorOutput: Contains Console application to run the program
2. SignalValidator: Contains Json file processor for reading and writting.
3. SignalValidator.BL: Business logic for Signal validator, which contains code to validate the input json file against User Rules.
4. SignalValidator.BLTest: Contains Unit testing script for Business logic.

Steps to Execute:
1. Replace the user rules file in the path "ConsoleSignalValidatorOutput\Input\" and file name should be "rules.json"
2. Replace the input file in the path "ConsoleSignalValidatorOutput\IOFiles" and file name should be "raw_data.json"
3. You can get the output in the path "ConsoleSignalValidatorOutput\IOFiles" and the file name will be "Result.json"
4. The input & output file names can be changed in the App.Config file.

Steps to Unit Test:
1. Replace the user rules file in the path "SignalValidator.BLTest\Input\" and file name should be "rules.json"
2. Replace the input file in the path "SignalValidator.BLTest\IOFiles" and file name should be "raw_data.json"
3. Replace the Expected output in the path "SignalValidator.BLTest\IOFiles" and the file name will be "UT_Result.json"
4. The files names were hardcoded in the code and to change it, needs to be modified in the code.

Assumption:
1. User rules should be in the Json format as present in the "ConsoleSignalValidatorOutput\Input\rules.json" file.


