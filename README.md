# EDisclosureMonitor

This program allows to monitor appearance of a specific financial information (quarterly and annual financial reports) on a russian finance disclosure portal https://e-disclosure.ru 

Program is parsing user-specified public web pages each 10 sec, so you don't need to purchase subscription to access their Rest API service.

When information matches specified regular expression - a sound is played and file archive with financial report downloaded, extracted and pdf file opened.
This program also helpful if you want quickly open specific fin. report file of a favorite companies directly from disclosure server

![Screenshot](https://i.snipboard.io/cAfVvP.jpg)

# How to use it

![Interface](https://i.snipboard.io/80oL1M.jpg)

1. Add line to list
2. Fill in the URL of a web page with financial reports for a company you interested in (see below)
3. Add friendly name for a line
4. Choose right regex template or write yours
5. Save a list
6. Press "Start" button (only checked items processed)

## How to get the URL and choose regex

1. Url of a web page with reports of a company
2. Standard string we're expecting/looking for and which we should use in regex
3. Next, if regex is mathed, program automatically looking for nearest http link which is going to be a link to zip or rar archive with pdf file and downloads it

![Screenshot](https://i.snipboard.io/BqTGiL.jpg)
