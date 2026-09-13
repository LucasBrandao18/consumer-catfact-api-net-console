# consumer-catfact-api-net-console
homework

# ConsumerCatFactApi


Aplicação de console em C# que consulta a API pública
[Cat Fact](https://catfact.ninja/fact), lê o JSON retornado e exibe o campo
`fact` após o título `Fato sobre Gatos:`.

## Como executar

É necessário ter o **SDK do .NET 10** instalado e conexão com a internet.
No terminal do VS Code, dentro da pasta `homework-catapi`, execute:

```powershell
dotnet run --project ConsumerCatFactApi.csproj
```

Exemplo de saída apresentado no enunciado:

```text
Fato sobre Gatos:
Many cats cannot properly digest cow's milk. Milk and milk products give them diarrhea.
```

O fato vem da API e pode variar a cada execução. O texto é exibido no idioma
original da resposta, conforme o exemplo da atividade.

## Arquivos

- `ConsumerCatFactApi.csproj`: configuração do projeto de console .NET.
- `Program.cs`: consulta HTTP, conversão do JSON e impressão do fato.
- `.gitignore`: exclusão de arquivos temporários de compilação.

O modelo `CatFact` representa os campos `fact` e `length` da resposta.
A saída exibe apenas o fato, como solicitado no item b). O programa também
informa erros de conexão, tempo limite ou resposta inválida.

Os itens **c)** (publicar no GitHub) e **d)** (entregar no Google Classroom)
não foram realizados, conforme solicitado.
