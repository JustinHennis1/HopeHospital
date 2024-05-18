   
google.charts.load('current', { packages: ['corechart'] });
google.charts.setOnLoadCallback(drawCharts);

function drawCharts() {
            drawPatientCountByYear();
            drawBasic();
 }

function drawPatientCountByYear() {

            var data = new google.visualization.DataTable();
            data.addColumn('number', 'X');
            data.addColumn('number', 'Patients');

            data.addRows([
                [0, 0], [1, 1000], [2, 2300], [3, 4700], [4, 5800], [5,4900],
                [6, 6100], [7, 5700], [8, 7300], [9, 8000], [10, 8200], [11, 9500],
                [12, 13000], [13, 12000], [14, 12200], [15, 11700], [16, 11400], [17, 12800],
                [18, 12200], [19, 13400], [20, 14200], [21, 15500], [22, 15600], [23, 15700],
                [24, 16000], [25, 15000], [26, 15200], [27, 15100], [28, 14900], [29, 15300],
                [30, 15500], [31, 16000], [32, 16001], [33, 15900], [34, 16200], [35, 16500],
                [36, 16200], [37, 15800], [38, 15500], [39, 16100], [40, 17400], [41, 17500],
                [42, 18300], [43, 19600], [44, 19700], [45, 21900], [46,23900], [47, 25000],
                [48, 27200], [49, 26800], [50, 26600], [51, 26500], [52, 26700], [53, 27000],
                [54, 27100], [55, 29200], [56, 32300], [57, 33500], [58, 34000], [59, 35800],
                [60, 36400], [61, 36000], [62, 36500], [63, 36700], [64, 36800], [65, 36900],
                [66, 37000], [67, 37200], [68, 37500], [69, 38000]
            ]);

    var options = {
            responsive: true,
            maintainAspectRatio: false, // Use aspect ratio option
            
                hAxis: {
                    title: 'Years Since Open'
                },
                vAxis: {
                    title: '# of Patients'
                }
            };

            var chart = new google.visualization.LineChart(document.getElementById('chart_div'));

        chart.draw(data, options);
    
 }

google.charts.load('current', { packages: ['corechart', 'bar'] });

function drawBasic() {

    var data = new google.visualization.DataTable();
    data.addColumn('timeofday', 'Time of Day');
    data.addColumn('number', '# of Visitors');

    data.addRows([
        [{ v: [8, 0, 0], f: '8 am' }, 13],
        [{ v: [9, 0, 0], f: '9 am' }, 24],
        [{ v: [10, 0, 0], f: '10 am' }, 86],
        [{ v: [11, 0, 0], f: '11 am' }, 40],
        [{ v: [12, 0, 0], f: '12 pm' }, 20],
        [{ v: [13, 0, 0], f: '1 pm' }, 20],
        [{ v: [14, 0, 0], f: '2 pm' }, 28],
        [{ v: [15, 0, 0], f: '3 pm' }, 64],
        [{ v: [16, 0, 0], f: '4 pm' }, 43],
        [{ v: [17, 0, 0], f: '5 pm' }, 32],
    ]);

    var options = {
        responsive: true,
        maintainAspectRatio: false, // Use aspect ratio option
       
        title: '# of Visitors Throughout the Day',
        hAxis: {
            title: 'Time of Day',
            format: 'h:mm a',
            viewWindow: {
                min: [7, 30, 0],
                max: [17, 30, 0]
            }
        },
        vAxis: {
            title: '# of Visitors'
        }
    };

    var chart = new google.visualization.ColumnChart(
        document.getElementById('chart_div2'));

    chart.draw(data, options);
}