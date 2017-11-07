function ErroMensagem(titulo, texto) {
    $.notify({
        title: titulo,
        message: texto,
    }, {
        type: 'danger',
        allow_dismiss: false,
        placement: {
            from: "top",
            align: "center"
        },
        animate: {
            enter: 'animated fadeInDown',
            exit: 'animated fadeOutUp'
        },
    });
}

function SucessoMensagem(titulo, texto) {
    $.notify({
        title: titulo,
        message: texto,
    }, {
        type: 'success',
        allow_dismiss: false,
        placement: {
            from: "top",
            align: "center"
        },
        animate: {
            enter: 'animated fadeInDown',
            exit: 'animated fadeOutUp'
        },
    });
}

function Enviando(titulo, texto) {
    $.notify({
        title: titulo,
        message: texto,
    }, {
        type: 'info',
        allow_dismiss: false,
        placement: {
            from: "top",
            align: "center"
        },
        animate: {
            enter: 'animated fadeInDown',
            exit: 'animated fadeOutUp'
        },
    });
}


