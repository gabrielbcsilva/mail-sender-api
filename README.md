# mail-sender-api
Api para serviço de email.

## Sobre

Esta API que tem como objetivo servir de forma simples uma aplicação que necessite utilizar o serviço de email. A partir do endpoint `/mails` o utilizador poderá enviar suas mensagens mediante a informação de Endereço SMPT, email do remetente, senha e porta que será utilizada.

## Features

Esta API fornece endpoints e ferramentas HTTP para:

* Enviar email `POST//mails`.

**Body:**

```json
{
  "emails": [
    "exemplo@gmail.com"
  ],
  "subject": "string",
  "body": "string",
  "isHtml": true
}
```

**Onde:**

`emails` - É a lista de destinatário de um único email.

`subject` - O título da mensagem.

`body` - O corpo do email.

`isHtml` - True para indicar que o corpo está formatado em HTML, false para não.


```

Retornos possíveis:

* 200- Ok: Tudo ocorreu como esperado.
* 400 - Bad Request: A requisição não foi aceita, geralmente devido à falta de um parâmetro obrigatório ou JSON inválido.
* 500 - Server Errors: Erro interno.



### Tecnologias utilizadas

Este projeto foi desenvolvido utilizando:

* **.Net 7.0**
* **Swagger**


### Documentação

* Swagger (development environment): [http://localhost:5000/swagger/index.html)

### Execução

* dotnet run
* Ou crie uma image com o Dockerfile e execute: sudo docker run
