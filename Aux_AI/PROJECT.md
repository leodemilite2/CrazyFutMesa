\# Crazy FutMesa



\## Visão Geral



Crazy FutMesa é um jogo de puzzle baseado em física inspirado no futebol de botão.



O jogador controla um botão e utiliza impulsos para conduzir uma bola até o alvo de cada fase. Cada nível apresenta um desafio diferente, exigindo planejamento, precisão e o menor número possível de impulsos.



O projeto busca oferecer uma experiência simples de aprender, mas difícil de dominar, recompensando jogadores que conseguem resolver os desafios com eficiência.



\---



\# Filosofia do Projeto



O foco principal do Crazy FutMesa é criar um jogo divertido, completo e polido.



A prioridade não é adicionar dezenas de mecânicas, mas sim construir uma experiência consistente do início ao fim.



Toda nova funcionalidade deve responder à pergunta:



> "Isso aproxima o jogo da versão 1.0?"



Caso contrário, ela deve permanecer no backlog para futuras atualizações.



\---



\# Loop Principal



O jogador:



1\. Escolhe uma fase.

2\. Analisa o cenário.

3\. Utiliza impulsos para movimentar a bola.

4\. Resolve o desafio.

5\. Recebe uma classificação por estrelas.

6\. Ganha recompensas.

7\. Desbloqueia novas fases.

8\. Continua sua progressão.



\---



\# Progressão



Concluir uma fase sempre desbloqueia a próxima.



As estrelas representam o desempenho do jogador.



Cada fase possui metas próprias de impulsos.



Exemplo:



⭐⭐⭐ Até 3 impulsos



⭐⭐ Até 5 impulsos



⭐ Até 10 impulsos



As recompensas seguem a filosofia:



⭐ Torcedores



⭐⭐ Nova bola



⭐⭐⭐ Novo time



Ao conquistar três estrelas, o jogador também recebe as recompensas das categorias anteriores.



\---



\# Sistemas do Jogo



\## Gameplay



\- Sistema de impulsos.

\- Física baseada em Rigidbody2D.

\- Obstáculos.

\- Alvo da fase.

\- Progressão entre fases.



\## Progressão



\- Sistema de estrelas.

\- Desbloqueio de fases.

\- Desbloqueio de bolas.

\- Desbloqueio de times.

\- Sistema de torcedores.



\## Persistência



\- SaveGame.

\- Progresso do jogador.

\- Recompensas desbloqueadas.



\---



\# Arquitetura Atual



\## GameManager



Responsável por:



\- fluxo da partida;

\- vitória;

\- reinício;

\- troca de fases;

\- contador de impulsos.



\## PlayerController



Responsável apenas pela interação do jogador.



\## BallController



Responsável pela física da bola.



\## GameConfig



Configurações globais do jogo.



\## LevelData (Sprint 9)



Cada fase possuirá sua própria configuração contendo:



\- quantidade de impulsos para cada estrela;

\- recompensas;

\- parâmetros específicos da fase.



\---



\# Escopo da Versão 1.0



A versão inicial do Crazy FutMesa deverá conter:



\- Menu Principal.

\- Seleção de fases.

\- Sistema de estrelas.

\- Sistema de recompensas.

\- SaveGame.

\- Progressão completa.

\- Diversas fases jogáveis.

\- Times desbloqueáveis.

\- Bolas desbloqueáveis.

\- Sistema de torcedores.



Novos obstáculos, efeitos especiais e mecânicas adicionais serão desenvolvidos após a conclusão da versão 1.0.



\---



\# Diretrizes de Desenvolvimento



Antes de iniciar qualquer Sprint:



\- Revisar este documento.

\- Revisar o Roadmap.

\- Definir um objetivo claro.



Durante a Sprint:



\- Implementar apenas funcionalidades necessárias para atingir o objetivo.

\- Evitar adicionar escopo não planejado.



Ao finalizar:



\- Atualizar documentação.

\- Registrar decisões importantes.

\- Atualizar o changelog.

\- Realizar commit.



\---



\# Objetivo Final



Criar um jogo de futebol de botão moderno, simples e divertido, onde a progressão baseada em habilidade incentiva o jogador a revisitar fases, melhorar seu desempenho e desbloquear novos conteúdos.


# Regra de Ouro

Sempre priorizar terminar um jogo completo antes de expandir seu conteúdo.

Um jogo simples e terminado vale mais do que um jogo enorme e inacabado.
