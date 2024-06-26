import androidx.lifecycle.ViewModel

class MainViewModel : ViewModel(){
    private val _greetingList = MutableStateFLow<List<String>>(listOf())
    val greetingList : StateFLow<List<String>> get() = _greetingList
}