package edu.itvo.mygestordefinanzas.presentacion.viewmodel

import androidx.lifecycle.ViewModel
import androidx.lifecycle.viewModelScope
import dagger.hilt.android.lifecycle.HiltViewModel
import edu.itvo.mygestordefinanzas.domain.model.Transaction
import edu.itvo.mygestordefinanzas.domain.model.UserPreferences
import edu.itvo.mygestordefinanzas.domain.usecase.*
import kotlinx.coroutines.flow.SharingStarted
import kotlinx.coroutines.flow.StateFlow
import kotlinx.coroutines.flow.combine
import kotlinx.coroutines.flow.stateIn
import kotlinx.coroutines.launch
import javax.inject.Inject

@HiltViewModel
class MainViewModel @Inject constructor(
    private val getUserUseCase: GetUserUseCase,
    private val loginUseCase: LoginUseCase,
    private val logoutUseCase: LogoutUseCase,
    private val updateThemeUseCase: UpdateThemeUseCase,
    private val updateNotificationsUseCase: UpdateNotificationsUseCase
) : ViewModel() {

    val userPreferences: StateFlow<UserPreferences> =
        getUserUseCase()
            .stateIn(
                scope = viewModelScope,
                started = SharingStarted.WhileSubscribed(5_000),
                initialValue = UserPreferences()
            )
    fun login(name: String, email: String, age: Int) {
        viewModelScope.launch {
            loginUseCase(name, email, age)
        }
    }

    fun logout() {
        viewModelScope.launch {
            logoutUseCase()
        }
    }

    fun updateTheme(isDark: Boolean) {
        viewModelScope.launch {
            updateThemeUseCase(isDark)
        }
    }

    fun updateNotifications(enabled: Boolean) {
        viewModelScope.launch {
            updateNotificationsUseCase(enabled)
        }
    }
}
