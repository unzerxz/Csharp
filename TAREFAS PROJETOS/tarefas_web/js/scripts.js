function CarregarTarefas() {
    var url = "http://localhost:5261/api/Tarefa"

    fetch(url)
        .then(response => response.json())
        .then(function (data) {
            console.log(data)

            var tarefas_concluidas = 0
            var tarefas_totais = 0
            var progresso = document.getElementById('dvProgresso')

            data.forEach(item => {
                InserirLinha(item.id, item.descricao, item.isConcluido)
                tarefas_totais++
                if (item.isConcluido)
                    tarefas_concluidas++
            })
            var tamanho = (tarefas_concluidas / tarefas_totais) * 100
            progresso.setAttribute('style', `width: ${tamanho}%;`)
            progresso.innerText = `${tamanho.toPrecision(3)}% Concluido`

        })
        .catch(function (error) {
            console.log("DEU RUIM" + error)
        })
}

CarregarTarefas()

function InserirLinha(id, descricao, isConcluido) {
    var tabela = document.getElementById("tbTarefas")
    var nlinhas = tabela.rows.length
    var linha = tabela.insertRow(nlinhas)

    var celula1 = linha.insertCell(0)
    var celula2 = linha.insertCell(1)
    var celula3 = linha.insertCell(2)
    var celula4 = linha.insertCell(3)

    celula1.innerHTML = id
    celula2.innerHTML = (isConcluido ? "Concluído" : "Pendente")
    celula3.innerHTML = descricao
    celula4.innerHTML = (isConcluido ?
        `<button class='btn btn-success'>Concluído</button>` :
        `<button class='btn btn-warning' onclick='abrirModal(${id})'>Pendente</button>`);

}

function criarTarefa(txt_descricao) {
    var url = "http://localhost:5261/api/Tarefa"

    var conteudo = {
        id: 1,
        descricao: txt_descricao,
        isConcluido: false
    }

    var cabecalho = {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(conteudo)
    }

    fetch(url, cabecalho)
        .catch((error) => {
            console.log("DEU RUIM:" + error)
        })
}

function abrirModal(id) {
    var modal = document.getElementById('confirmarModal')
    var myModal = new bootstrap.Modal(modal)
    var botao = document.getElementById('btConcluir')

    botao.setAttribute('onclick', `atualizarTarefa(${id})`)

    myModal.show()
}

function atualizarTarefa(id) {
    var url = "http://localhost:5261/api/Tarefa/" + id;

    var conteudo = {
        id: id
    }

    var cabecalho = {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(conteudo)
    }

    fetch(url, cabecalho)
        .catch((error) => {
            console.log("DEU RUIM:" + error)
        })
}