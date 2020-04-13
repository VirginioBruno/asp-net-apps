class Carrinho
{
    incrementaQuantidade(element) {
        var item = this.getData(element);
        item.Quantidade++;
        this.postData(item);
    }

    decrementaQuantidade(element) {
        var item = this.getData(element);
        if (this.validaItem(item)) {
            item.Quantidade--;
            this.postData(item);
        }
    }

    updateQuantidade(input) {
        var item = this.getData(input);
        this.postData(item);
    }

    getData(element) {
        var linhaItem = $(element).parents('[item-id]');
        var itemId = $(linhaItem).attr('item-id');
        var qtde = $(linhaItem).find('input').val();

        return {
            Id: itemId,
            Quantidade: qtde
        };
    }

    validaItem(item) {
        if (item.Quantidade == 0)
            return false;

        return true;
    }

    postData(data) {

        var token = $('[name=__RequestVerificationToken]').val();
        var headers = {};
        headers['RequestVerificationToken'] = token;

        $.ajax({
            url: '/Pedido/UpdateQuantidade',
            type: 'Post',
            contentType: 'application/json',
            data: JSON.stringify(data),
            headers: headers
        }).done(function (response) {
            let item = response.itemPedido
            let carrinho = response.carrinhoViewModel;

            let linhaItem = $('[item-id=' + item.id + ']');
            linhaItem.find('input').val(item.quantidade);
            linhaItem.find('[subtotal]').html((item.subtotal).duasCasas());

            $('[numero-itens]').html('Total: ' + carrinho.itens.length + ' Itens');
            $('[total]').html((carrinho.total).duasCasas());

            if (item.quantidade == 0) {
                linhaItem.remove();
            }
        });
    }
}

var carrinho = new Carrinho();

Number.prototype.duasCasas = function () {
    return this.toFixed(2).replace('.', ',');
}