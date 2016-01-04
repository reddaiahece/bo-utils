**BO-Utils** provides an easy to use bulk report scheduling solution embedded in Excel. It enables users to automate report scheduling with customized prompts and to download them to the desired format. It was originally designed for testing purpose. The installation is done on the client side station. It doesn't require any Business Objects installation and it's compatible from XIR2 to BI4 FP3**.**

![http://bo-utils.googlecode.com/svn/wiki/sc_ribbon.png](http://bo-utils.googlecode.com/svn/wiki/sc_ribbon.png)

It comes useful to :
  * To quickly generate reports with specific prompts for acceptance testing.
  * To quickly identify reports changes for regression testing by comparing the generated Excel/Pdf/Xml/Html to the previous one.
  * To download a batch of documents on your desktop in a single click to the desired format.
  * To quickly identify succeed, pending, and scheduled documents in a single click.
  * To quickly recover previous used prompts.
  * To clean documents instances in a single click.
  * To run tasks with an external task scheduler.


![http://bo-utils.googlecode.com/svn/wiki/sc_architecture.png](http://bo-utils.googlecode.com/svn/wiki/sc_architecture.png)


### Features ###
Get a list of reports in an Excel sheet
  * Filter reports on a path or on a list of ids
  * Retrieve prompts of the report
  * Retrieve prompts of the last created, succeed or failed instance of a report
Schedule reports
  * With or without prompts
  * To the specific format (Default/Excel/Pdf)
  * At a specific time if specified
  * To a destination folder on the server side if specified
  * Send a email report at the end of scheduling if specified
  * Wait the end of scheduling if specified
  * Delete instances at the end of scheduling if specified
  * Save the configuration plan to an XML file that can be then used in a command line
Get reports instance status
  * Of the specified instance
  * Of the last created instance
  * Of the last succeed instance
  * Of the last failed instance
Download Reports
  * Of the report itself
  * Of the specified instance
  * Of the last succeed instance
  * At the specified format : Pdf, Excel, XML, HTML
Delete non recurrent reports instances
  * Of the specified instance
  * Of the last succeed instance scheduled once
  * Of the last failed instance scheduled once
  * All instances scheduled once

### Limitations ###
Scheduling an ObjectPackage or a Pulication is not currently possible

### Author ###
> Florent BREHERET