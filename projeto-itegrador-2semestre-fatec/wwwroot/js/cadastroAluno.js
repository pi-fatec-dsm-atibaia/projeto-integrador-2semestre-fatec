const profileForm = document.getElementById("cadastro-form");

profileForm.addEventListener('submit', function (event) {
    event.preventDefault();
});



function handleConfirmacao() {
    const senha = document.getElementById('senha').value;
    const confirmacao = document.getElementById('confirme').value;
    const error = document.getElementById('errorSenha');

    if (senha !== confirmacao) {
        error.innerText = "Senhas não coincidem";
        error.style.display = 'flex';
        return;
    }
    error.style.display = 'none';
}

function handleCreateAccount() {
    const nome = document.getElementById('nome').value;
    const email = document.getElementById('email').value;
    const CPF = document.getElementById('CPF').value;
    const RA = document.getElementById('RA').value;
    const uni = document.getElementById('unidade').value;
    const curso = document.getElementById('curso').value;
    const sem = document.getElementById('semestre').value;
    const senha = document.getElementById('senha').value;
    const confirmacao = document.getElementById('confirme').value;

    // Regex para validações
    const regexNome = /^[A-Za-zÀ-ÿ\s]+$/; // Permite apenas letras e espaços
    const regexEmail = /^[^\s@]+@[^\s@]+\.[^\s@]+$/; // Validação básica de e-mail
    const regexCPF = /^\d{11}$/; // CPF deve conter exatamente 11 números
    const regexRA = /^\d{13}$/; // RA deve conter 13 números


    // Validação do nome
    if (!regexNome.test(nome)) {
        console.log("Nome inválido. Deve conter apenas letras e espaços.");
        const errorNome = document.getElementById('errorNome');
        errorNome.innerText = "* Nome inválido. Deve conter apenas letras e espaços.";
        errorNome.style.display = 'flex';
        return;
    }

    // Validação do email
    if (!regexEmail.test(email)) {
        console.log("Email inválido. Use o formato exemplo@dominio.com.");
        const errorEmail = document.getElementById('errorEmail');
        errorEmail.innerText = "* Email inválido. Use o formato exemplo@dominio.com";
        errorEmail.style.display = 'flex';
        return;
    }

    // Validação do CPF
    if (!regexCPF.test(CPF)) {
        console.log("CPF inválido. Deve conter exatamente 11 números.");
        const errorCPF = document.getElementById('errorCPF');
        errorCPF.innerText = "* CPF inválido. Deve conter exatamente 11 números.";
        errorCPF.style.display = 'flex';
        return;
    }

    // Validação do RA
    if (!regexRA.test(RA)) {
        console.log("RA inválido. Deve conter 13 números.");
        const errorRA = document.getElementById('errorRA');
        errorRA.innerText = "* RA inválido. Deve conter exatamente 13 números.";
        errorRA.style.display = 'flex';
        return;
    }

    // Validação da unidade
    if (uni.length < 1 || !uni) {
        console.log("Unidade inválida. Selecione uma das opções.");
        const errorUni = document.getElementById('errorUni');
        errorUni.innerText = "* Unidade inválida. Selecione uma das opções.";
        errorUni.style.display = 'flex';
        return;
    }

    // Validação do curso
    if (curso.length < 1 || !curso) {
        console.log("Curso inválido. Selecione uma das opções.");
        const errorCurso = document.getElementById('errorCurso');
        errorCurso.innerText = "* Curso inválido. Selecione uma das opções."
        errorCurso.style.display = 'flex';
        return;
    }

    // // Validação do semestre
    if (sem.length < 1 || !sem) {
        console.log("Semestre inválido. Selecione uma das opções.");
        const errorSem = document.getElementById('errorSem');
        errorSem.innerText = "* Semestre inválido. Selecione uma das opções.";
        errorSem.style.display = 'flex';
        return;
    }

    // Validação das senhas
    if (senha.length <= 8 || !senha) {
        console.log("Digite uma senha com mais de 8 caracteres");
        const errorSenha = document.getElementById('errorSenha1');
        errorSenha.innerText = "* Digite uma senha com mais de 8 caracteres";
        errorSenha.style.display = 'flex';
        return;

    } else if (senha !== confirmacao) {
        console.log("Senhas não coincidem.");
        const errorConfirme = document.getElementById('errorSenha');
        errorConfirme.innerText = "* Senhas não coincidem.";
        errorConfirme.style.display = 'flex';
        return;

    } else {
        const errorSenha = document.getElementById('errorSenha1');
        errorSenha.style.display = 'none';
        const errorConfirme = document.getElementById('errorSenha');
        errorConfirme.style.display = 'none';
    }

    // Caso tudo seja válido
    changePage('dashboard-aluno', 'dashboard-aluno.html');
}
