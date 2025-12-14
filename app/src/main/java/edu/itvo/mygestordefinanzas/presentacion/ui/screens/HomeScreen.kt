package edu.itvo.mygestordefinanzas.presentacion.ui.screens

import androidx.compose.foundation.layout.Arrangement
import androidx.compose.foundation.layout.Box
import androidx.compose.foundation.layout.Column
import androidx.compose.foundation.layout.Spacer
import androidx.compose.foundation.layout.fillMaxSize
import androidx.compose.foundation.layout.padding
import androidx.compose.material3.Button
import androidx.compose.material3.MaterialTheme
import androidx.compose.material3.Text
import androidx.compose.runtime.Composable
import androidx.compose.runtime.collectAsState
import androidx.compose.runtime.getValue
import androidx.compose.runtime.mutableStateOf
import androidx.compose.runtime.remember
import androidx.compose.runtime.setValue
import androidx.compose.ui.Modifier
import androidx.compose.ui.unit.dp
import androidx.hilt.navigation.compose.hiltViewModel
import edu.itvo.mygestordefinanzas.domain.model.Transaction
import edu.itvo.mygestordefinanzas.domain.model.UserPreferences
import edu.itvo.mygestordefinanzas.presentacion.viewmodel.TransactionViewModel
import androidx.compose.material.icons.Icons
import androidx.compose.material.icons.filled.Settings
import androidx.compose.material3.Icon
import androidx.compose.material3.IconButton
import androidx.compose.foundation.layout.Row
import androidx.compose.foundation.layout.fillMaxWidth
import androidx.compose.foundation.layout.height
import androidx.compose.material.icons.automirrored.filled.ExitToApp
import androidx.compose.material.icons.filled.Add
import androidx.compose.material.icons.filled.ExitToApp
import androidx.compose.material3.FloatingActionButton
import androidx.compose.material3.OutlinedButton
import androidx.compose.material3.Scaffold
import androidx.compose.ui.Alignment

@Composable
fun HomeScreen(
    preferences: UserPreferences,
    onLogout: () -> Unit,
    onThemeChange: (Boolean) -> Unit,
    onNotificationToggle: (Boolean) -> Unit,
    onAddTransaction: () -> Unit,
    transactionViewModel: TransactionViewModel = hiltViewModel()
) {
    val transactions by transactionViewModel.transactions.collectAsState()
    var showSettings by remember { mutableStateOf(false) }

    Scaffold(
        containerColor = MaterialTheme.colorScheme.background,
        floatingActionButton = {
            FloatingActionButton(onClick = onAddTransaction, containerColor = MaterialTheme.colorScheme.primary) {
                Icon(
                    imageVector = Icons.Default.Add,
                    contentDescription = "Agregar movimiento",
                    tint = MaterialTheme.colorScheme.onPrimary
                )            }
        }
    ) { padding ->

        Column(
            modifier = Modifier
                .padding(padding)
                .padding(16.dp),
            verticalArrangement = Arrangement.spacedBy(20.dp)
        ) {

            // HEADER
            Row(
                modifier = Modifier.fillMaxWidth(),
                horizontalArrangement = Arrangement.SpaceBetween,
                verticalAlignment = Alignment.CenterVertically
            ) {
                Column {
                    Text(
                        text = "Hola, ${preferences.name}",
                        style = MaterialTheme.typography.titleLarge
                    )
                    Text(
                        text = "Resumen de tus movimientos",
                        style = MaterialTheme.typography.bodyMedium,
                        color = MaterialTheme.colorScheme.onSurfaceVariant
                    )
                }

                Row {
                    IconButton(onClick = { showSettings = true }) {
                        Icon(
                            imageVector = Icons.Default.Settings,
                            contentDescription = "Configuración"
                        )
                    }

                    IconButton(onClick = onLogout) {
                        Icon(
                            imageVector = Icons.Default.ExitToApp,
                            contentDescription = "Cerrar sesión",
                            tint = MaterialTheme.colorScheme.error
                        )
                    }
                }
            }


            // STATS
            StatsCard(transactions)

            // MOVIMIENTOS
            Text(
                text = "Movimientos recientes",
                style = MaterialTheme.typography.titleMedium
            )

            TransactionListCard(
                transactions = transactions,
                onDelete = { transactionViewModel.delete(it) }
            )

            Spacer(modifier = Modifier.height(8.dp))

        }
    }

    // CONFIGURACIÓN
    if (showSettings) {
        SettingsDialog(
            isDarkTheme = preferences.darkTheme,
            notificationsEnabled = preferences.notificationsEnabled,
            onThemeChange = onThemeChange,
            onNotificationsChange = onNotificationToggle,
            onDismiss = { showSettings = false }
        )
    }
}
