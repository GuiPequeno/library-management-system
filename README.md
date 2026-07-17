# library-management-system
📚 Sistema de Gerenciamento de Biblioteca

Um sistema de console desenvolvido em C# para gerenciamento de livros e categorias, aplicando conceitos de Orientação a Objetos e persistência de dados em arquivos planos.

## 🚀 Funcionalidades
- **Adicionar Livros:** Cadastra novos livros gerando IDs automáticos incrementais. Os dados são salvos no arquivo CSV em ordem alfabética.
- **Remover Livros:** Exclusão segura utilizando ID como chave primária, prevenindo falhas silenciosas e corrupção de dados.
- **Aumentar/Diminuir Estoque:** Cada livro tem uma quantidade de cópias que pode ser alterada de forma segura, com prevenção e tratamento de erros.

## 🛠️ Tecnologias Utilizadas
- C# (.NET 8.0 ou a versão que você usou)
- LINQ (Language Integrated Query) para ordenação e buscas eficientes
- Persistência em arquivos CSV

## 📝 Aprendizados e Desafios Técnicos
Durante o desenvolvimento, deparei-me com o comportamento de concorrência de arquivos no Windows (`IOException`), resolvido posicionando corretamente o ciclo de vida dos blocos `using`. Também tratei as diferenças regionais de separadores de listas do Excel (Vírgula vs Ponto e Vírgula) usando 'sep=,'. Por fim, foram feitos os tratamentos de erros de input do usuário.

## 🎮 Como Executar o Projeto
1. Clone este repositório: `git clone https://github.com/seu-usuario/seu-repositorio.git`
2. Abra a solução (.sln) no Visual Studio.
3. Pressione `F5` ou clique em `Start` para rodar a aplicação no console.erenciamento nde biblioteca em console c# com persistência de dados em arquivo CSV
