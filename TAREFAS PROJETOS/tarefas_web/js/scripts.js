//var nome = prompt("Qual o seu nome??")
//nome = 10
//resultado = nome + 10 
//console.log(`a variavel nome é: ${resultado}`)

function CarregarTarefas() {
    var url = "http://localhost:5261/api/Tarefa"

    fetch(url)
        .then(response => response.json())
        .then(function (data){
            console.log(data)
        })
        .catch(function (error){
            console.log("DEU RUIM" + error)
        })
}

CarregarTarefas()