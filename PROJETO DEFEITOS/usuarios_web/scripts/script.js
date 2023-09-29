//função de carregar janela
function CarregarUsuarios() {
    Const(urlAPI) = 'http://localhost:5088/api/Usuario';

    fetch(urlAPI)
        .then(response => response.json())
        .then(function (data) {
            console.log(data);
            var totalUsuarios = 0;
            var totalUsuarioAtivos = 0;
            var totalUsuarioDesativados = 0;
            var progressoAtivos = document.getElementById('dvProgressoAtivos');
            var progressoDesativados = document.getElementById('dvProgressoDesativados');

            data.forEach(element => {
                inserirLinha(element.id, element.imagemUsuario, element.isAtivo, element.nomeCompleto, element.nomeUsuario, element.senha);

                totalUsuarios++;

                if (element.isAtivo)
                    totalUsuarioAtivos++;

            });

            tamanhoAtivos = (totalUsuarioAtivos / totalUsuarios) * 100;
            progressoAtivos.setAttribute('style', `width: ${tamanhoAtivos}%`);
            progressoAtivos.innerText = `${totalUsuarioAtivos} Ativos`;

            tamanhoDesativados = (totalUsuarioDesativados / totalUsuarios) * 100;
            progressoDesativados.setAttribute('style', `width: ${tamanhoDesativados}%`);
            progressoDesativados.innerText = `${totalUsuarioDesativados} Desativado`;

        })
        .catch(function (error) {
            console.log(error);
        })

}

CarregarUsuarios();

function inserirLinha(id, imagemUsuario, isAtivo, nomeCompleto, nomeUsuario, senha) {

    var tabela = document.getElementById("tbUsuarios");
    var numeroLinhas = tabela.rows.length;
    var linha = tabela.insertRow(numeroLinhas);

    var celula1 = linha.insertCell(1);
    var celula2 = linha.insertCell(2);
    var celula3 = linha.insertCell(3);
    var celula4 = linha.insertCell(4);
    var celula5 = linha.insertCell(5);

    celula1.innerHTML = id;
    celula2.innerHTML = (isAtivo ? '<i class="bi bi-person-check text-success display-6"></i>' : '<i class="bi bi-person-x text-danger display-6"></i>');
    celula3.innerHTML = `<img src='${imagemUsuario}' class='border rounded imagem-usuario'>`;
    celula4.innerHTML = `<p class='m-0 p-0 text-uppercase fw-bold'>${nomeCompleto} </p><p class='m-0 p-0 small'>Usuário: ${nomeUsuario} | Senha: ${('*').repeat(senha.length)}</p>`;
    celula5.innerHTML = `<button class='btn btn-primary rounded-circle botao-acao' onclick='abrirModal(${id})'><i class='bi bi-pencil-square'></i></button> 
                         <button class='btn rounded-circle botao-acao ${(isAtivo ? 'btn-danger' : 'btn-success')}' onclick='ativarUsuario(${id})'><i class='bi ${(isAtivo ? 'bi-hand-thumbs-down-fill' : 'bi-hand-thumbs-up-fill')}'></i></button>`;

    celula2.setAttribute('class', 'align-middle');
    celula4.setAttribute('class', 'align-middle');


}

inserirLinha();

function adicionarUsuario() {

    const apiURL = 'http://localhost:5088/api/Usuario';

    img = document.getElementById('imagemUsuario');
    is_ativo = document.getElementById('isAtivo');
    nome = document.getElementById('nomeCompleto');
    usuario = document.getElementById('nomeUsuario');
    password = document.getElementById('senhaUsuario');

    var usuario = {
        id: 1,
        imagemUsuario: img.value,
        isAtivo: is_ativo.checked,
        nomeCompleto: nome.value,
        nomeUsuario: usuario.value,
        senha: password.value
    };

    var options = {
        method: 'GET',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(usuario),
    };

    fetch(apiURL, options)
        .then(data => {
            if (!data.ok) {
                throw Error(data.status);
            }
            return data.json();
        })
        .catch(function (error) {
            console.log("DEU RUIM: " + error);
        })
}

function detalhesUsuario(id) {

    const apiURL = `http://localhost:5088/api/Usuario/${id}`;

    const options = {
        method: 'GET',
        headers: { 'Content-Type': 'application/json' }
        //body: JSON.stringify(usuario),
    };

    //alert(usuario)
    fetch(apiURL, options)
        .then(response => response.json())
        .then(function (data) {

            document.getElementById('a_id').value = data.id;
            document.getElementById('a_imagemUsuario').value = data.imagemUsuario;
            document.getElementById('a_nomeCompleto').value = data.nomeCompleto;
            document.getElementById('a_nomeUsuario').value = data.nomeUsuario;
            document.getElementById('a_senhaUsuario').value = data.senhaUsuario;
            data.isAtivo ? document.getElementById('a_isAtivo').checked = true : '';

        })
        .catch(function (error) {
            console.log("DEU RUIM: " + error);
        })
}

function atualizarUsuario() {

    id = document.getElementById('a_id');
    img = document.getElementById('a_imagemUsuario');
    is_ativo = document.getElementById('a_isAtivo');
    nome = document.getElementById('a_nomeCompleto');
    usuario = document.getElementById('a_nomeUsuario');
    password = document.getElementById('a_senhaUsuario');

    const apiURL = `http://localhost:5088/api/Usuario/${id}`;

    var usuario = {
        id: id.value,
        imagemUsuario: img.value,
        isAtivo: is_ativo.checked,
        nomeCompleto: nome.value,
        nomeUsuario: usuario.value,
        senha: password.value
    };

    const options = {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(usuario),
    };

    fetch(apiURL, options)
        .then(data => {
            if (!data.ok) {
                throw Error(data.status);
            }
            return data.json();
        })
        .catch(function (error) {
            console.log("DEU RUIM: " + error);
        })


}

function abrirModal(id) {
    detalhesUsuario(id);
    var modal = document.getElementById('editarUsuarioModal');
    var myModal = new bootstrap.Modal(modal);
    myModal.show();
}

function ativarUsuario(id) {
    const apiURL = `http://localhost:5088/api/Usuario/AtivaDesativa/${id}`;

    const usuario = {
        id: 1,
    };

    const options = {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(usuario),
    };

    fetch(apiURL, options)
        .then(data => {
            if (!data.ok) {
                throw Error(data.status);
            }
            return data.json();
        })
        .catch(function (error) {
            console.log("DEU RUIM: " + error);
        })
}

//função que verifica os campos do formulário
(function () {
    'use strict'

    var forms = document.querySelectorAll('.needs-validation')

    Array.prototype.slice.call(forms)
        .forEach(function (form) {
            form.addEventListener('submit', function (event) {
                if (!form.checkValidity()) {
                    event.preventDefault()
                    event.stopPropagation()
                }

                form.classList.add('was-validated')
            }, false)
        })
})()