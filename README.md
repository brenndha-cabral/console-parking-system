# 🚗 Console Parking System

Sistema de gerenciamento de estacionamento desenvolvido em console, que permite controlar a entrada, saída, listagem e cobrança de veículos de forma simples e prática.

---

## 📝 Descrição

Este projeto é um sistema de estacionamento que funciona via terminal (linha de comando), desenvolvido para controlar o fluxo de veículos, registrar entradas, calcular tempo de permanência e gerar cobranças automaticamente.
É ideal para aprendizado de lógica de programação, estruturas de dados e manipulação básica de arquivos, além de ser um projeto simples para uso pessoal ou base para sistemas mais complexos.

---

## ⚙️ Funcionalidades

- Registrar entrada de veículos
- Registrar saída de veículos
- Calcular valor a ser cobrado baseado no tempo de permanência
- Listar veículos estacionados no momento
- Sistema simples de controle via linha de comando

---

## 🛠 Tecnologias Utilizadas

- C#
- .NET
- Ambiente: Console/Terminal

---

## 🧠 Decisões de Projeto

- **Estrutura Modular**: Separação clara entre lógica de negócios e interação com o usuário.
- **Utilização de Listas**: Uso de dicionários para armazenar dinamicamente os veículos estacionados.
- **Interface Simples**: Menu interativo no console para facilitar a navegação e operação do sistema.

---

## 📋 Regras de Negócio

- **Tarifação**:
  - Cobrança automática mediante ao tempo de uso.
- **Registro de Veículos**:
  - Apenas placas válidas são aceitas.
  - Não é permitido registrar o mesmo veículo mais de uma vez simultaneamente.
- **Remoção de Veículos**:
  - Ao remover um veículo, o sistema calcula o tempo de permanência e exibe o valor a ser pago.
  - O veículo só é removido se a tarifa for paga.

---

## ✅ Validações Implementadas

- **Placa do Veículo**:
  - Verificação de formato válido (ex: ABC-1234) considerando modelo antigo e novo de placas.
  - Prevenção de duplicatas.
- **Entrada de Dados**:
  - Tratamento de opções inválidas no menu para evitar falhas na execução.

---

## 🚀 Como Executar Localmente

### Pré-requisitos

- [.NET SDK 9.0 ou superior](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)

### Passos

1. Clone o repositório:
   ```bash
   git clone https://github.com/brenndha-cabral/console-parking-system.git
   cd console-parking-system

2. Restaure as dependências (caso necessário):

   ```bash
   dotnet restore
   
2. Compile e execute o projeto:

   ```bash
   dotnet run

---

## 📁 Estrutura do Projeto

- `console-parking-system/`
  - `Models/`
    - `Parking.cs` – Classe que representa o estacionamento com seus métodos
  - `Program.cs` – Ponto de entrada da aplicação
  - `console-parking-system.csproj` – Arquivo de configuração do projeto .NET
  - `README.md` – Documentação do projeto

---

## 📌 Sobre

Feito com dedicação por [Brenndha Cabral](https://www.linkedin.com/in/brenndhacabral/) como parte do processo de aprendizagem.  
Este repositório representa minha jornada de estudos, prática e crescimento na área de desenvolvimento de software 🚀
