package edu.itvo.mygestordefinanzas.presentacion.ui.screens

import androidx.compose.runtime.Composable
import androidx.compose.runtime.collectAsState
import androidx.compose.runtime.getValue
import androidx.hilt.navigation.compose.hiltViewModel
import edu.itvo.mygestordefinanzas.domain.model.UserPreferences
import edu.itvo.mygestordefinanzas.presentacion.viewmodel.MainViewModel

@Composable
fun MainScreen(
    viewModel: MainViewModel,
    onAddTransaction: () -> Unit
) {
    val preferences by viewModel.userPreferences
        .collectAsState(initial = UserPreferences())

    if (preferences.isLoggedIn) {
        HomeScreen(
            preferences = preferences,
            onLogout = { viewModel.logout() },
            onThemeChange = { viewModel.updateTheme(it) },
            onNotificationToggle = { viewModel.updateNotifications(it) },
            onAddTransaction = onAddTransaction
        )
    } else {
        LoginScreen(
            onLogin = { name, email, age ->
                viewModel.login(name, email, age)
            }
        )
    }
}


