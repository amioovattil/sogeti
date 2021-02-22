This is a test automation code written in C#.
The project file is intented to be builded and run using Microsoft Visual Studio 2019.

Running the test cases using Microsoft Visual Studio 2019
------------------------------------------------------------------------------------------------
1) Clone / download the source file from GitHub or from email attachment
2) Open the solution (SogetiTests.sln) file using Microsoft Visual Studio 2019.
2) Rebuild the project using MainMeu->Build->Rebuild Solution
3) Open the Test explorer window (MainMeu->Test->Test Explorer)
4) Click on the 'Run all test' tool button inside 'Test Explorer' window.
5) Above operation will run all the test cases one after the other inside Chrome and Edge.


Play the already recorded video
--------------------------------
As a alternative plan I have created a video of the entire test run in my local machine using the tool OBStudio.
I have uploaded the video file in the GitHub under the Video directory.
This video could be used to have a quick look at the running process.

Test report
--------------------------------
I have experience in setting up the sources under Azure Devops and run the test under a pipeline and this will generate nice graphs on project Dashboard.

In this particlar case I have created a .TRX file using the command 'vstest.console.exe SogetiTests.dll /logger:trx'.
Thereafter I have used a small utility (TrxToHtml.exe) to generate a html report and the html file is attached in this email.
