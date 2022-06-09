function myFunc(p1, p2) {
    return p1 * p2;
}

function generateLineGraph(data_arr, label, elementId) {
    const ctx = document.getElementById(elementId).getContext('2d');
    const data_test = {
        datasets: [{
        label: 'My First dataset',
        backgroundColor: 'rgb(255, 99, 132)',
        borderColor: 'rgb(255, 99, 132)',
        data: data_arr
        }]
  };
    let config = {
    type: 'line',
    data: data_test,
    options: {
        responsive: true,
        plugins: {
        legend: {
            position: 'top',
        },
        title: {
            display: true,
            text: 'Chart.js Line Chart'
        }
        }
    },
    };

    const myChart = new Chart(
        ctx,
        config
    );

}