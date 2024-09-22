<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="A4_screenshot.aspx.cs" Inherits="A4_PDF_DOWNLOAD.A4_screenshot" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Screenshot A4 Size</title>
    <style>
        body {
            margin: 0;
            padding: 0;
        }
        #capture {
            position: relative;
            width: 210mm; /* A4 Width */
            height: 297mm; /* A4 Height */
            background-image: url('A40.PNG'); /* Add your watermark image */
            background-size: cover; /* Adjust as needed */
            padding: 20px; /* Padding around content */
            box-sizing: border-box;
        }
        #capture h1, h2, h3, h6 {
            text-align: center;
            margin: 0px;
        }

    </style>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/html2canvas/1.4.1/html2canvas.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="capture">
           <br />
            <h2>Tata Memorial Centre</h2>
            <h2>Tata Memorial Hospital</h2>
            <h3>Parel, Mumbai - 400 012</h3>
            <h6>Phone: (+91-22) 24177000, 24177300, 69537300</h6>
            
            <br />
            <br />
            <br />
            <h2>Receipt</h2>

            <p style="FLOAT: inline-end;">DATED: 22/09/2024</p> 

            <p style="margin-left: 80px;">Received with thanks from     Salim Salman Khan</p>
            <p style="margin-left: 80px;FLOAT: inline-end;">On Account of <br />BY CASH Rs 2500.00 </p>
            <p style="margin-left: 80px;">a sum of Rupees TWO THOUSAND FIVE HUNDRED ONLY </p>
            

            <BR />
            <BR />
            <BR />
            <CENTER>SMART CARD DEPOSIT NOT VALID FOR REIMBURSEMENT</CENTER>
         
        </div>
        <button type="button" id="btnCapture">Capture Screenshot</button>
    </form>

    <script>
        document.getElementById('btnCapture').addEventListener('click', function () {
            html2canvas(document.getElementById('capture')).then(function (canvas) {
                const link = document.createElement('a');
                link.href = canvas.toDataURL('image/png');
                link.download = 'screenshot.png'; // Set the file name
                link.click();
            });
        });
    </script>
</body> 
</html>
