<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Chart.aspx.cs" Inherits="WebApplication1.two_step_authorization.Chart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Financial Graph - GST & Tax</title>
    <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Financial Data (Last 5 Years)</h2>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="True"></asp:GridView>
            <canvas id="financeChart" width="400" height="200"></canvas>
        </div>

        <script>
            function loadChart(labels, gstPayments, gstReturns, taxPayments, taxReturns) {
                var ctx = document.getElementById('financeChart').getContext('2d');
                var chart = new Chart(ctx, {
                    type: 'bar',
                    data: {
                        labels: labels,
                        datasets: [
                            { label: 'GST Payment', data: gstPayments, backgroundColor: 'rgba(255, 99, 132, 0.5)' },
                            { label: 'GST Return', data: gstReturns, backgroundColor: 'rgba(54, 162, 235, 0.5)' },
                            { label: 'Tax Payment', data: taxPayments, backgroundColor: 'rgba(255, 206, 86, 0.5)' },
                            { label: 'Tax Return', data: taxReturns, backgroundColor: 'rgba(75, 192, 192, 0.5)' }
                        ]
                    }
                });
            }
        </script>
    </form>
</body>
</html>
