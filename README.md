# Unity_LifeManager
 - 게임오브젝트 점진적 파괴 + 오브젝트 풀링
 - 싱글톤 클래스로 구현
　

  
## 1. 게임오브젝트의 점진적 파괴
 - 게임오브젝트 파괴 퍼포먼스 최적화
 - 짧은 순간 내에 다수의 게임오브젝트가 파괴됨으로써 발생하는 랙을 방지할 수 있다.
 - 파괴할 게임오브젝트들을 비활성화 후, 잠시 큐에 저장해두었다가 일정한 주기로 하나씩 꺼내어 파괴하는 방식을 사용한다.
 - 큐에 담긴 게임 오브젝트의 개수에 따라 파괴 주기가 달라지도록 구현되어 있다.  
 
 
<br>
  
## 2. 오브젝트 풀링
 - 게임오브젝트를 파괴하거나 생성하는 대신, 오브젝트 풀(Object Pool)에 저장하거나 꺼내는 방식으로 퍼포먼스를 향상시킨다.
 - 오브젝트 풀에 저장할 게임오브젝트 개수를 지정할 수 있다.
   <br> -> ``` public const int _PoolMaxSize = 20; ```
 - 게임오브젝트를 파괴하는 대신에, 풀에 저장한다.
   <br> (만약 해당 게임오브젝트가 풀 내에 지정된 최대 개수만큼 저장되어 있을 경우, 풀에 추가로 저장하지 않고 파괴한다.)
 - 게임오브젝트를 생성할 때, 오브젝트 풀에 해당 게임오브젝트가 저장되어 있을 경우, 새롭게 생성하지 않고 풀에서 꺼내어 로드한다.
 
 
<br>
  
## 3. 사용법
 ### [1] 오브젝트 파괴
  - ``` LifeManager.Instance.
  
 ### [2] 오브젝트 풀링
  - 게임오브젝트 생성 또는 풀에서 로드하기
    <br> (해당 게임오브젝트가 오브젝트 풀 내에 존재하는 경우에는 풀에서 로드하고, 존재하지 않는 경우에 새롭게 생성한다.)
    <br> -> ``` LifeManager.Instance.Instantiate() ``` 또는
    <br> ``` LifeManager.Instance.Create() ```
  - 
