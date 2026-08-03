\# Sessão 02



Sprint: 7



Tempo: \~1 hora



\## Entregas



\- Correção da física

\- Ajuste dos materiais físicos

\- Correção de colisões

\- Criação do prefab Obstacle

\- Construção de três primeiras fases

\- Validação da diversão da mecânica



\## Lições



A posição dos obstáculos gera mais variedade do que adicionar novas mecânicas.



\## Próxima Sprint



Criar o primeiro loop completo de progressão.



\# Sessão - Sprint 8



\## Objetivos concluídos



\- Finalizada a arquitetura principal do gameplay.

\- Implementado GameManager.

\- Implementado BallController.

\- Implementada progressão entre fases.

\- Implementado reinício da fase.

\- Implementada troca de fases.

\- Corrigida colisão da bola com obstáculos.

\- Revisada arquitetura do projeto.



\## Decisões importantes



\- PhysicsManager removido.

\- GameConfig passa a centralizar parâmetros globais.

\- BallController será responsável exclusivamente pela física da bola.

\- A Sprint 9 focará em concluir o jogo antes de adicionar novas mecânicas.



# Sessão — Definição do roadmap do MVP

Data: 03/08/2026

## Objetivo da sessão

A sprint do dia foi utilizada para organizar ideias, revisar o escopo do MVP e definir os próximos passos do desenvolvimento do Crazy FutMesa.

Nenhuma funcionalidade foi implementada nesta sessão. O foco foi exclusivamente planejamento e game design.

---

## Decisões tomadas

### Filosofia do jogo

O Crazy FutMesa será um jogo de puzzle estratégico com partidas curtas, no qual o jogador deve enxergar todo o desafio antes de executar a jogada.

Princípios:

- câmera fixa;
- fases curtas;
- estratégia acima da habilidade;
- mapa totalmente visível;
- progressão simples.

---

## Decisão sobre a câmera

Foi decidido manter a câmera fixa durante todo o MVP.

Não haverá:

- câmera seguindo o jogador;
- mapas gigantes;
- movimentação automática da câmera.

Foi aprovada apenas a implementação de zoom limitado em uma sprint futura.

---

## Sprint 11 — Objetos simples

### Obstáculos fixos

- paredes côncavas;
- paredes convexas;
- copos;
- garrafas.

### Obstáculos passivos

- cigarros;
- caixas de fósforo;
- zagueiros.

---

## Sprint 12 — Objetos animados

- goleiro horizontal;
- placa giratória;
- plataforma sobe e desce.

---

## Sprint 13 — Áreas de reset

As seguintes áreas provocarão reset instantâneo da fase:

- buraco;
- área vermelha;
- linha lateral;
- linha de fundo.

O comportamento será exatamente o mesmo do botão "Reiniciar" do HUD.

---

## Sprint 14 — Áreas especiais

### Cerveja derramada

Aumenta significativamente o atrito.

### Gelo

Diminui significativamente o atrito.

### Ventilador

Aplica uma força direcional exclusivamente à bolinha.

Exemplos:

- vento para a direita;
- vento para a esquerda;
- vento para cima;
- vento para baixo.

---

## Sprint 15 — Sistema de câmera

- zoom configurável por fase;
- zoom in limitado;
- zoom out limitado;
- botão para restaurar o zoom padrão.

---

## Funcionalidades fora do MVP

- loja;
- ranking;
- conquistas;
- multiplayer;
- câmera dinâmica;
- mapas gigantes.

---

## Estado atual do projeto

Sprint 10 concluída com sucesso:

- coleção;
- cosméticos;
- seleção de bolas;
- seleção de times;
- PlayerVisual;
- BallVisual;
- persistência do save.

O projeto deixou a fase de protótipo técnico e entrou na fase de produção do MVP.