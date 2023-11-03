# Relatório Automatizado de Frações Tratadas

### Descrição da Aplicação

Esta é uma aplicação do tipo _"Stand-alone executable"_. Ela tem a capacidade de interagir com o sistema _"**Eclipse**"_ por meio da _"**Eclipse Scripting Application Programming Interface - ESAPI**"_. O propósito principal desta aplicação é efetuar uma varredura no banco de dados e gerar um relatório diário e automatizado das frações tratadas no formato de arquivo .csv como saída.

#

### O que nós vamos aprender?

-   Inicializar uma aplicação via _**Eclipse Script Wizard**_
-   Entender a estrutura de uma aplicação em _[.NET Framework](https://learn.microsoft.com/pt-br/dotnet/framework/get-started/ 'Introdução ao .NET Framework')_ utilizando a liguagem de programação orientação a objeto (OOP) - _[C#](https://learn.microsoft.com/en-us/dotnet/csharp/ 'Documentação do C#')_
-   Manipulação de arquivos - **arquivo.csv**
-   Trabalhar com coleções e manipulá-las com o _[LINQ - Language-Integrated Query](https://learn.microsoft.com/en-us/dotnet/csharp/linq/ 'Introdução ao LINQ')_
-   Manipulação das classes e funcionalidades da **API** para implementar a varredura do banco de dados com filtragem de cursos e planejamentos
-   Compilação e execução da solução.

#

### Passo-a-passo da implementação da aplicação

1. Criando o arquivo de saída de dados


     <span style="font-size: 12px">
    Neste momento implementamos a lógica de criação do arquivo de saída dos dados. Vamos trabalhar com o formato de arquivo .csv. O formato CSV é uma opção preferencial devido à sua capacidade de armazenar dados tabulares de maneira eficiente, separando os valores por vírgulas. Isso facilita a interoperabilidade com diversos sistemas e aplicativos.
     </span>

###

2. Criando o header e definindo a data de início da busca

    <span style="font-size: 12px">
    O header irá definir quais serão os dados que vamos armazenar em nosso arquivo. A data de início de busca irá nos ajudar a filtrar nossa busca pelos pacientes em tratamento, melhorando assim a performance da aplicação.
    </span>

###

3. Implementando o método de varredura do banco de dados

    <span style="font-size: 12px">
     Iremos extrair os dados demográficos de todos os pacientes do banco de dados e armazená-los em uma coleção de dados. Em seguida, percorreremos essa coleção para iniciar a filtragem dos pacientes de interesse.
    </span>

###
4. Filtragem de cursos de tratamento e planejamentos

    <span style="font-size: 12px">
     Esta etapa é crucial, pois definirá quais pacientes estão em tratamento. Para identificar quais pacientes estão em tratamento, avançaremos para a obtenção das coleções de cursos e planejamentos, a fim de realizar a filtragem utilizando o LINQ.
    </span>

###
5. Implementando a contagem de frações tratadas e escrevendo no arquivo de saída dos dados

    <span style="font-size: 12px">
     Após adquirir o planejamento do paciente em tratamento, obeteremos a coleção com as informações sobre as frações de tratamento associadas a esse plano específico e, em seguida, percorreremos a coleção para identificar as frações marcadas como tratadas. Subsequentemente, registraremos os resultados no arquivo de saída de dados
    </span>

Após a conclusão dos cinco passos, estamos prontos para compilar nossa aplicação e executar o arquivo .exe gerado durante a compilação.

**OBS:** As aplicações do tipo _**stand-alone**_ devem ser executadas no mesmo ambiente em que o **Eclipse** está instalado. Portanto, se você estiver desenvolvendo a aplicação no **TBOX**, poderá executá-la normalmente. No entanto, para os usuários do **CITRIX**, a aplicação deve ser executada no servidor **CITRIX**.

##
### Dicas e Orientações Finais!!!

- [Download do Visual Studio Community 2019](https://visualstudio.microsoft.com/pt-br/vs/older-downloads/)
- [Curso Completo de Programação Orientada a Objetos](https://www.udemy.com/course/programacao-orientada-a-objetos-csharp/)


| Versão do Eclipse | Versão do .NET Framework |
| ------ | ------ |
| V16+| V 4.6.1 |
| V15.6 ou V15.5 | V 4.5 |
