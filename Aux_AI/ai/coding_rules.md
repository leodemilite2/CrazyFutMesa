\# Coding Rules



\- Código simples.

\- Evitar números mágicos.

\- Uma responsabilidade por classe.

\- Comentar apenas quando necessário.

\- Uma mecânica principal por Sprint.

\- Commits pequenos.



\## Física



Antes de escrever código para resolver um problema de física, verificar primeiro as configurações nativas da Unity.



Priorizar soluções da engine sempre que possível.


- Cada mecânica deve ser um prefab independente.
- Não acoplar mecânicas ao GameManager.
- Objetos devem possuir scripts próprios.
- Prefabs animados herdam de AnimatedObstacle.
- Áreas especiais herdam de AreaEffect.